"use strict";
var ModuleInstanceItem = (function () {
    function ModuleInstanceItem(moduleName, instanceName) {
        this.isReady = false;
        this.isLoaded = false;
        this.readyEvents = new Array();
        this.dataReadyEvents = new Array();
        this.moduleName = moduleName;
        this.instanceName = instanceName;
    }
    ModuleInstanceItem.prototype.ready = function (fn) {
        if (this.isReady)
            fn(this.instance);
        else
            this.readyEvents.push(fn);
    };
    ModuleInstanceItem.prototype.dataReady = function (fn) {
        if (this.isReady)
            fn(this.instance);
        else
            this.dataReadyEvents.push(fn);
    };
    return ModuleInstanceItem;
}());
var ApplicationLoader = (function () {
    function ApplicationLoader() {
        var _this = this;
        this.moduleInstanceItems = {};
        this.documentIsReady = false;
        $(document).ready(function () {
            _this.documentIsReady = true;
            for (var instanceName in _this.moduleInstanceItems) {
                var instance = _this.moduleInstanceItems[instanceName];
                if (instance.isLoaded && !instance.isReady) {
                    _this.makeModuleReady(instance, instance.instance);
                }
            }
        });
    }
    ApplicationLoader.prototype.makeModuleReady = function (instance, module) {
        instance.isReady = true;
        var i;
        for (i in instance.dataReadyEvents) {
            instance.dataReadyEvents[i](module);
        }
        if (module) {
            module.bind();
            if (module.data) {
                module.data._bevents._viewModel = module;
            }
        }
        for (i in instance.readyEvents) {
            instance.readyEvents[i](module);
        }
        if (module && module.documentReady) {
            module.documentReady();
        }
    };
    ApplicationLoader.prototype.createModuleInstance = function (moduleName, instanceName, data) {
        var _this = this;
        if (this.moduleInstanceItems[instanceName])
            throw instanceName + " isimli instance zaten mevcut ! [" + moduleName + "]";
        var instance = new ModuleInstanceItem(moduleName, instanceName);
        this.moduleInstanceItems[instanceName] = instance;
        var appName = moduleName.split("/")[0];
        SystemJS["import"]("bentas").then(function () {
            SystemJS["import"]("Bentas").then(function (m) {
                if (appName === "Bentas") {
                    var core = m["Core"].getInstance();
                    core.ObservableObject = new m["Observable"];
                    core.observable = core.ObservableObject.observable;
                    instance.instance = core;
                    window[instanceName] = core;
                    instance.isLoaded = true;
                    if (_this.documentIsReady) {
                        _this.makeModuleReady(instance, undefined);
                    }
                }
                else {
                    SystemJS["import"](appName).then(function () {
                        SystemJS["import"](moduleName).then(function (m) {
                            var mdl = moduleName.substring(moduleName.lastIndexOf("/") + 1).replace(/\./g, "");
                            if (!m[mdl]) {
                                var err = "\"" + mdl + "\" isimli modül bulunamadı !";
                                throw err;
                            }
                            var module = new m[mdl];
                            instance.instance = module;
                            module.instanceName = instanceName;
                            window[instanceName] = module;
                            if (data) {
                                module.data = module.observable(data);
                            }
                            instance.isLoaded = true;
                            if (_this.documentIsReady) {
                                _this.makeModuleReady(instance, module);
                            }
                        });
                    });
                }
            });
        });
    };
    return ApplicationLoader;
}());
window.applicationLoader = new ApplicationLoader();
window.applicationLoader.createModuleInstance("Bentas", "bentas");
