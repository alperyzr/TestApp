"use strict";
var __spreadArray = (this && this.__spreadArray) || function (to, from, pack) {
    if (pack || arguments.length === 2) for (var i = 0, l = from.length, ar; i < l; i++) {
        if (ar || !(i in from)) {
            if (!ar) ar = Array.prototype.slice.call(from, 0, i);
            ar[i] = from[i];
        }
    }
    return to.concat(ar || Array.prototype.slice.call(from));
};
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
System.register("Menu", [], function (exports_1, context_1) {
    "use strict";
    var Menu;
    var __moduleName = context_1 && context_1.id;
    return {
        setters: [],
        execute: function () {
            Menu = (function () {
                function Menu() {
                    this.menuModalBackground = $("<div class='b__overlay'></div>");
                }
                Menu.prototype.initMenu = function () {
                    var isOpen = 0;
                    var navToggle = $('.b__nav--toggle');
                    var mobileNav = $('.b__mobile--nav');
                    var content = $('.b__container');
                    var menuWidth = $('.b__mobile--nav').css('width');
                    var menuWidthInverse = "-" + menuWidth;
                    $(navToggle).click(function (e) {
                        e.stopPropagation();
                        if (isOpen === 0) {
                            $(mobileNav).animate({ 'left': '0px' }, 300);
                            $(mobileNav).addClass('b__shadow--menu');
                            $(content).animate({ 'right': menuWidthInverse }, 300);
                            $(navToggle).removeClass('b__icon-menu-bar');
                            $(navToggle).addClass('b__icon-menu-bar');
                            isOpen++;
                        }
                        else {
                            $(mobileNav).animate({ 'left': menuWidthInverse }, 300);
                            $(mobileNav).removeClass('b__shadow--menu');
                            $(content).animate({ 'right': 0 }, 300);
                            $(navToggle).removeClass('b__icon-menu-bar');
                            $(navToggle).addClass('b__icon-menu-bar');
                            isOpen--;
                        }
                    });
                    $(document).on('click', '.b__mobile--nav', function (e) {
                        e.stopPropagation();
                    });
                    $(document).on('click', '.b__navbar--brand', function (e) {
                        e.stopPropagation();
                    });
                    $(document).click(function (e) {
                        if (isOpen === 1) {
                            $(mobileNav).animate({ 'left': menuWidthInverse }, 300);
                            $(mobileNav).removeClass('b__shadow--menu');
                            $(content).animate({ 'right': 0 }, 300);
                            $(navToggle).removeClass('b__icon-close');
                            $(navToggle).addClass('b__icon-menu-bar');
                            isOpen = 0;
                        }
                    });
                    var primaryLink = $('.b__mobile--nav ul li a');
                    var subMenu = $('.b__mobile--nav ul li .b__sub--menu');
                    $(primaryLink).click(function () {
                        $(this).next().slideToggle(250);
                        $(this).children("span").toggleClass("b__icon-caret-down b__icon-caret-up ");
                    });
                    $(window).scroll(this.menuStickyRelocate);
                    this.menuStickyRelocate();
                };
                Menu.prototype.menuModalOpen = function () {
                    this.menuModalBackground.appendTo("body");
                    $("body, html").css("overflow", "hidden");
                };
                Menu.prototype.menuModalClose = function () {
                    $("body, html").css("overflow", "auto");
                    this.menuModalBackground.detach();
                };
                Menu.prototype.menuStickyRelocate = function () {
                    var window_top = $(window).scrollTop();
                    var div_top = $('#sticky-anchor').offset();
                    if (div_top != undefined) {
                        if (window_top > div_top.top && $('.b__mobile--nav').position().left >= 0) {
                            $('.b__mobile--nav').addClass('stick');
                            $('#sticky-anchor').height($('.b__mobile--nav').outerHeight());
                            $('.b__header .b__mobile--nav--container').height("98%");
                        }
                        else {
                            $('.b__mobile--nav').removeClass('stick');
                            $('#sticky-anchor').height(0);
                            $('.b__header .b__mobile--nav--container').height("95%");
                        }
                    }
                };
                return Menu;
            }());
            exports_1("Menu", Menu);
        }
    };
});
System.register("Dialog", [], function (exports_2, context_2) {
    "use strict";
    var DialogButton, DialogOptions, Dialog;
    var __moduleName = context_2 && context_2.id;
    return {
        setters: [],
        execute: function () {
            DialogButton = (function () {
                function DialogButton(init) {
                    var _this = this;
                    this.text = "";
                    this.primary = false;
                    this.default = false;
                    this.clicked = false;
                    this.dialogid = "";
                    this.onClickProxy = function (e) {
                        if (_this.onclick) {
                            var r = _this.onclick(e, _this, $("#" + _this.dialogid).data("kendoDialog"));
                            if (r === true)
                                _this.clicked = true;
                            return r === true;
                        }
                        _this.clicked = true;
                        return true;
                    };
                    if (init) {
                        this.text = init.text;
                        this.primary = init.primary;
                        this.default = init.default;
                        this.clicked = init.clicked;
                        this.onclick = init.onclick;
                        this.dialogid = init.dialogid;
                    }
                }
                return DialogButton;
            }());
            exports_2("DialogButton", DialogButton);
            DialogOptions = (function () {
                function DialogOptions(init) {
                    this.title = "";
                    this.titleClass = "";
                    this.height = null;
                    this.width = 300;
                    this.buttonLayout = "normal";
                    this.closable = false;
                    this.extraOptions = {};
                    if (init) {
                        this.title = init.title;
                        this.content = init.content;
                        this.titleClass = init.titleClass;
                        this.height = init.height;
                        this.width = init.width;
                        this.buttonLayout = init.buttonLayout;
                        this.buttons = init.buttons;
                        this.open = init.open;
                        this.close = init.close;
                        this.closable = init.closable;
                    }
                }
                return DialogOptions;
            }());
            exports_2("DialogOptions", DialogOptions);
            Dialog = (function () {
                function Dialog() {
                }
                Dialog.showDialog = function (param) {
                    var dialogOptions = (new Object());
                    dialogOptions.modal = true;
                    dialogOptions.visible = false;
                    dialogOptions.title = param.title;
                    dialogOptions.buttonLayout = param.buttonLayout;
                    dialogOptions.height = param.height === -1 ? null : param.height;
                    dialogOptions.width = param.width;
                    dialogOptions.closable = param.closable;
                    dialogOptions.extraOptions = param.extraOptions;
                    if (param.content == null || typeof param.content === 'undefined')
                        param.content = "";
                    var wContent = param.content.parent ? "" : param.content;
                    var wContentElement = param.content.parent ? param.content : undefined;
                    var wContentElementParent = undefined;
                    if (wContentElement)
                        wContentElementParent = wContentElement.parent();
                    dialogOptions.content = wContent;
                    var dialogid = "bentas-window-dialogbox-" + kendo.guid();
                    var dialogButtons = new Array();
                    var kendoButtons = new Array();
                    for (var index in param.buttons) {
                        var button = param.buttons[index];
                        var btn = void 0;
                        if (typeof button === "string") {
                            btn = new DialogButton();
                            btn.text = button;
                            param.buttons[index] = btn;
                        }
                        else if (button instanceof DialogButton) {
                            btn = button;
                        }
                        else {
                            btn = new DialogButton(button);
                        }
                        btn.primary = btn.default = btn.primary || btn.default;
                        btn.dialogid = dialogid;
                        var kendoBtn = (new Object());
                        kendoBtn.action = btn.onClickProxy;
                        kendoBtn.primary = btn.primary;
                        kendoBtn.text = btn.text;
                        kendoButtons.push(kendoBtn);
                        dialogButtons.push(btn);
                    }
                    if (dialogButtons.length === 1) {
                        dialogButtons[0].primary = true;
                        dialogButtons[0].default = true;
                        kendoButtons[0].primary = true;
                    }
                    else if (dialogButtons.length > 1) {
                        var def_1 = false;
                        dialogButtons.forEach(function (b) { def_1 = def_1 || b.default; });
                        if (!def_1) {
                            dialogButtons[0].primary = true;
                            dialogButtons[0].default = true;
                            kendoButtons[0].primary = true;
                        }
                    }
                    dialogOptions.actions = kendoButtons;
                    dialogOptions.open = function (e) {
                        $("body, html ").css("overflow", "hidden");
                        e.sender.wrapper.find(".k-dialog-titlebar").addClass(param.titleClass);
                        if (wContentElement) {
                            wContentElement.css("display", "block").appendTo(e.sender.wrapper.find(".k-dialog-content"));
                        }
                        if (param && param.open) {
                            param.open(e, $("#" + dialogid).data("kendoDialog"));
                        }
                    };
                    dialogOptions.close = function (e) {
                        $("body, html ").css("overflow", "");
                        var dialog = $("#" + dialogid).data("kendoDialog");
                        if (param && param.close) {
                            param.close(e, dialog);
                        }
                        var b = undefined;
                        for (var index in dialogButtons) {
                            var button = dialogButtons[index];
                            if (button && button.clicked === true) {
                                b = { index: parseInt(index), button: button, dialog: dialog };
                                break;
                            }
                        }
                        if (wContentElement) {
                            wContentElement.css("display", "none").appendTo(wContentElementParent);
                        }
                        e.sender.result.resolve(b);
                        $("#" + dialogid).remove();
                    };
                    var wnd = $("<div id='" + dialogid + "'></div>").appendTo("body").kendoDialog(dialogOptions).data("kendoDialog");
                    wnd.result = $.Deferred();
                    wnd.open();
                    return wnd.result;
                };
                Dialog.checkButtons = function (buttons) {
                    if (buttons === undefined)
                        buttons = new Array();
                    if (buttons.length === 0) {
                        var btn = new DialogButton();
                        btn.text = "Tamam";
                        buttons.push(btn);
                    }
                    return buttons;
                };
                Dialog.information = function (paramOrContent, width, height) {
                    var param;
                    if (paramOrContent instanceof DialogOptions) {
                        param = paramOrContent;
                    }
                    else {
                        param = new DialogOptions();
                        param.title = "";
                        param.content = paramOrContent;
                        if (width)
                            param.width = width;
                        if (height)
                            param.height = height;
                    }
                    param.titleClass = "b__dialog--info";
                    param.buttons = this.checkButtons(param.buttons);
                    return this.showDialog(param);
                };
                ;
                Dialog.informationTitle = function (title, content, width, height) {
                    return Dialog.information(new DialogOptions({ title: title, content: content, width: width, height: height }));
                };
                ;
                Dialog.error = function (paramOrContent, width, height) {
                    var param;
                    if (paramOrContent instanceof DialogOptions) {
                        param = paramOrContent;
                    }
                    else {
                        param = new DialogOptions();
                        param.title = "";
                        param.content = paramOrContent;
                        if (width)
                            param.width = width;
                        if (height)
                            param.height = height;
                    }
                    param.titleClass = "b__dialog--error";
                    param.buttons = this.checkButtons(param.buttons);
                    return this.showDialog(param);
                };
                ;
                Dialog.errorTitle = function (title, content, width, height) {
                    return Dialog.error(new DialogOptions({ title: title, content: content, width: width, height: height }));
                };
                ;
                Dialog.confirmation = function (paramOrContent, buttons, width, height) {
                    var param;
                    if (paramOrContent instanceof DialogOptions) {
                        param = paramOrContent;
                    }
                    else {
                        param = new DialogOptions();
                        param.title = "";
                        param.content = paramOrContent;
                        if (buttons)
                            param.buttons = buttons;
                        if (width)
                            param.width = width;
                        if (height)
                            param.height = height;
                    }
                    param.titleClass = "b__dialog--confirmation";
                    param.buttons = this.checkButtons(param.buttons);
                    return this.showDialog(param);
                };
                ;
                Dialog.confirmationTitle = function (title, content, buttons, width, height) {
                    return Dialog.confirmation(new DialogOptions({ title: title, content: content, buttons: buttons, width: width, height: height }));
                };
                ;
                Dialog.warning = function (paramOrContent, width, height) {
                    var param;
                    if (paramOrContent instanceof DialogOptions) {
                        param = paramOrContent;
                    }
                    else {
                        param = new DialogOptions();
                        param.title = "";
                        param.content = paramOrContent;
                        if (width)
                            param.width = width;
                        if (height)
                            param.height = height;
                    }
                    param.titleClass = "b__dialog--warning";
                    param.buttons = this.checkButtons(param.buttons);
                    return this.showDialog(param);
                };
                ;
                Dialog.warningTitle = function (title, content, width, height) {
                    return Dialog.warning(new DialogOptions({ title: title, content: content, width: width, height: height }));
                };
                ;
                Dialog.custom = function (paramOrContent, buttons, width, height) {
                    var param;
                    if (paramOrContent instanceof DialogOptions) {
                        param = paramOrContent;
                    }
                    else {
                        param = new DialogOptions();
                        param.title = "";
                        param.content = paramOrContent;
                        if (buttons)
                            param.buttons = buttons;
                        if (width)
                            param.width = width;
                        if (height)
                            param.height = height;
                    }
                    param.buttons = this.checkButtons(param.buttons);
                    return this.showDialog(param);
                };
                ;
                Dialog.customTitle = function (title, content, buttons, width, height) {
                    return Dialog.custom(new DialogOptions({ title: title, content: content, buttons: buttons, width: width, height: height }));
                };
                ;
                return Dialog;
            }());
            exports_2("Dialog", Dialog);
        }
    };
});
System.register("Observable", ["Core"], function (exports_3, context_3) {
    "use strict";
    var Core_1, Observable;
    var __moduleName = context_3 && context_3.id;
    return {
        setters: [
            function (Core_1_1) {
                Core_1 = Core_1_1;
            }
        ],
        execute: function () {
            Observable = (function () {
                function Observable() {
                    var _this = this;
                    this.core = Core_1.Core.getInstance();
                    this._internal_ObservableToJSON = function () {
                        var that = this;
                        var o = $.extend({}, that);
                        if (o._bevents) {
                            delete o._bevents;
                        }
                        if (o._bmethods) {
                            delete o._bmethods;
                        }
                        if (o._find) {
                            delete o._find;
                        }
                        for (var prop in o) {
                            if (o[prop] instanceof kendo.data.DataSource) {
                                if (!o[prop].options._bForEvents) {
                                    o[prop] = o[prop].data().toJSON();
                                }
                                else {
                                    delete o[prop];
                                }
                            }
                        }
                        return o.toJSON();
                    };
                    this._internal_observableToJSONStringify = function (object) {
                        var that = this;
                        return JSON.stringify(that._toJSON());
                    };
                    this.observable = function (object) {
                        var o = $.extend({}, object);
                        o._bevents = {};
                        o._bmethods = {};
                        o._find = {};
                        o._bevents._viewModel = undefined;
                        o._bmethods.save = undefined;
                        o._bmethods.cancel = undefined;
                        o._bmethods.print = undefined;
                        o._bevents._allFields_AfterChange = undefined;
                        o._bevents._allFields_BeforeChange = undefined;
                        o._bevents._internalBeforeFieldChange = function (e) {
                            _this.core.printDebugInfo("internalBeforeFieldChange", e);
                            var field = _this.core.replaceAll(e.field, "\\.", "");
                            if (e.sender._bevents[field + "_BeforeChange"])
                                e.sender._bevents[field + "_BeforeChange"](e);
                            if (e.sender._bevents._viewModel && e.sender._bevents._viewModel["data" + field + "BeforeChange"])
                                e.sender._bevents._viewModel["data" + field + "BeforeChange"](e);
                            if (e.sender._bevents["_allFields_BeforeChange"])
                                e.sender._bevents["_allFields_BeforeChange"](e);
                            if (e.sender._bevents._viewModel && e.sender._bevents._viewModel["dataAllFieldsBeforeChange"])
                                e.sender._bevents._viewModel["dataAllFieldsBeforeChange"](e);
                        };
                        o._bevents._internalAfterFieldChange = function (e) {
                            _this.core.printDebugInfo("internalAfterFieldChange", e);
                            var field = _this.core.replaceAll(e.field, "\\.", "");
                            if (e.sender._bevents[field + "_AfterChange"])
                                e.sender._bevents[field + "_AfterChange"](e);
                            if (e.sender._bevents._viewModel && e.sender._bevents._viewModel["data" + field + "AfterChange"])
                                e.sender._bevents._viewModel["data" + field + "AfterChange"](e);
                            if (e.sender._bevents["_allFields_AfterChange"])
                                e.sender._bevents["_allFields_AfterChange"](e);
                            if (e.sender._bevents._viewModel && e.sender._bevents._viewModel["dataAllFieldsAfterChange"])
                                e.sender._bevents._viewModel["dataAllFieldsAfterChange"](e);
                            _this.core.refreshAllDropDownTexts();
                        };
                        var oo = kendo.observable(o);
                        oo.bind("set", oo._bevents._internalBeforeFieldChange);
                        oo.bind("change", oo._bevents._internalAfterFieldChange);
                        for (var prop in oo) {
                            if (oo[prop] instanceof kendo.data.DataSource) {
                                oo[prop].read();
                                _this._bindDataSourceEvents(oo[prop], prop);
                            }
                            else if (prop !== "constructor" && object[prop] && _this.core.options.createObservableEmptyEvents) {
                                oo._bevents[prop + "_BeforeChange"] = undefined;
                                oo._bevents[prop + "_AfterChange"] = undefined;
                            }
                        }
                        oo.__proto__._toJSON = _this._internal_ObservableToJSON;
                        oo.__proto__._toString = _this._internal_observableToJSONStringify;
                        return oo;
                    };
                }
                Observable.prototype._bindDataSourceEvents = function (ds, name) {
                    var _this = this;
                    if (!ds._bevents) {
                        ds._bevents = {};
                        ds._bevents._name = name;
                        ds._bevents._beforeInsert = undefined;
                        ds._bevents._afterInsert = undefined;
                        ds._bevents._beforeDelete = undefined;
                        ds._bevents._afterDelete = undefined;
                        ds._bevents._allFields_BeforeChange = undefined;
                        ds._bevents._allFields_AfterChange = undefined;
                        ds._bentashack_insert = ds.insert;
                        ds.insert = function (index, model) {
                            var module = ds.parent()._bevents._viewModel;
                            var name = ds._bevents._name;
                            var result = true;
                            if (ds._bevents["_beforeInsert"])
                                result = ds._bevents["_beforeInsert"](index, model);
                            if (module && name) {
                                if (module["data" + name + "BeforeInsert"])
                                    result = module["data" + name + "BeforeInsert"](index, model);
                            }
                            if (result)
                                return ds._bentashack_insert(index, model);
                        };
                        ds._bentashack_remove = ds.remove;
                        ds.remove = function (item) {
                            var module = ds.parent()._bevents._viewModel;
                            var name = ds._bevents._name;
                            var result = true;
                            if (ds._bevents["_beforeDelete"])
                                result = ds._bevents["_beforeDelete"](item);
                            if (module && name) {
                                if (module["data" + name + "BeforeDelete"])
                                    result = module["data" + name + "BeforeDelete"](item);
                            }
                            if (result)
                                return ds._bentashack_remove(item);
                        };
                        ds._bevents._internalChange = function (e) {
                            var core = _this.core;
                            core.printDebugInfo("internalChange", e);
                            var module = ds.parent()._bevents._viewModel;
                            var name = ds._bevents._name;
                            switch (e.action) {
                                case "add":
                                    for (var i = 0; i < e.items.length; i++) {
                                        e.items[i].bind("set", e.sender._bevents._internalBeforeFieldChange);
                                        e.items[i].bind("change", e.sender._bevents._internalAfterFieldChange);
                                    }
                                    if (e.sender instanceof kendo.data.DataSource) {
                                        if (ds.options && ds.options.schema && ds.options.schema.model) {
                                            var model = ds.options.schema.model;
                                            if (model.id && model.id !== "") {
                                                if (model.fields && model.fields[model.id] && model.fields[model.id].defaultValue && model.fields[model.id].defaultValue === "newguid") {
                                                    e.items[0].set(model.id, kendo.guid());
                                                }
                                            }
                                        }
                                    }
                                    if (e.sender._bevents["_afterInsert"])
                                        e.sender._bevents["_afterInsert"](e);
                                    if (module && name) {
                                        if (module["data" + name + "AfterInsert"])
                                            module["data" + name + "AfterInsert"](e);
                                    }
                                    break;
                                case "remove":
                                    if (e.sender._bevents["_afterDelete"])
                                        e.sender._bevents["_afterDelete"](e);
                                    if (module && name) {
                                        if (module["data" + name + "AfterDelete"])
                                            module["data" + name + "AfterDelete"](e);
                                    }
                                    break;
                                case undefined:
                                    _this._bindDataSourceEvents(e.sender, "");
                                    break;
                            }
                            return true;
                        };
                        ds._bevents._internalBeforeFieldChange = function (e) {
                            _this.core.printDebugInfo("internalBeforeFieldChange", e);
                            var name = ds._bevents._name;
                            var module = ds.parent()._bevents._viewModel;
                            var field = _this.core.replaceAll(e.field, "\\.", "");
                            if (ds._bevents[field + "_BeforeChange"])
                                ds._bevents[field + "_BeforeChange"](e);
                            if (module && name) {
                                if (module["data" + name + field + "BeforeChange"])
                                    module["data" + name + field + "BeforeChange"](e);
                            }
                            if (ds._bevents["_allFields_BeforeChange"])
                                ds._bevents["_allFields_BeforeChange"](e);
                            if (module && name) {
                                if (module["data" + name + "AllFieldsBeforeChange"])
                                    module["data" + name + "AllFieldsBeforeChange"](e);
                            }
                        };
                        ds._bevents._internalAfterFieldChange = function (e) {
                            _this.core.printDebugInfo("internalAfterFieldChange", e);
                            var name = ds._bevents._name;
                            var module = ds.parent()._bevents._viewModel;
                            var field = _this.core.replaceAll(e.field, "\\.", "");
                            if (ds._bevents[field + "_AfterChange"])
                                ds._bevents[field + "_AfterChange"](e);
                            if (module && name) {
                                if (module["data" + name + field + "AfterChange"])
                                    module["data" + name + field + "AfterChange"](e);
                            }
                            if (ds._bevents["_allFields_AfterChange"])
                                ds._bevents["_allFields_AfterChange"](e);
                            if (module && name) {
                                if (module["data" + name + "AllFieldsAfterChange"])
                                    module["data" + name + "AllFieldsAfterChange"](e);
                            }
                            _this.core.refreshAllDropDownTexts();
                        };
                        ds.bind("change", ds._bevents._internalChange);
                        if (this.core.options.createObservableEmptyEvents && ds.options && ds.options.schema && ds.options.schema.model && ds.options.schema.model.fields) {
                            for (var prop in ds.options.schema.model.fields) {
                                ds._bevents[prop + "_BeforeChange"] = undefined;
                                ds._bevents[prop + "_AfterChange"] = undefined;
                            }
                        }
                    }
                    for (var i = 0; i < ds.data().length; i++) {
                        var item = ds.data()[i];
                        if (!item._events._bvalidateEventBinded) {
                            item.bind("set", ds._bevents._internalBeforeFieldChange);
                            item.bind("change", ds._bevents._internalAfterFieldChange);
                            item._events._bvalidateEventBinded = true;
                        }
                    }
                };
                ;
                return Observable;
            }());
            exports_3("Observable", Observable);
        }
    };
});
System.register("Core", ["Menu", "Dialog", "Bentas"], function (exports_4, context_4) {
    "use strict";
    var Menu_1, Dialog_1, Bentas_1, CoreOptions, Core;
    var __moduleName = context_4 && context_4.id;
    return {
        setters: [
            function (Menu_1_1) {
                Menu_1 = Menu_1_1;
            },
            function (Dialog_1_1) {
                Dialog_1 = Dialog_1_1;
            },
            function (Bentas_1_1) {
                Bentas_1 = Bentas_1_1;
            }
        ],
        execute: function () {
            CoreOptions = (function () {
                function CoreOptions() {
                    this.internalDebugInfo = false;
                    this.createObservableEmptyEvents = true;
                }
                return CoreOptions;
            }());
            exports_4("CoreOptions", CoreOptions);
            Core = (function () {
                function Core() {
                    var _this = this;
                    this.signaleRListeners = new Array();
                    this.options = new CoreOptions();
                    this.onCloseDropDownList = function (e) {
                        _this.refreshDropDownText(e.sender.element);
                    };
                    this.onPopUpDropDownList = function (e) {
                        var ddl = e.sender;
                        var totalWidth = parseInt($(e.sender.element).attr("data-total-width"));
                        var lastColWidth = 0;
                        ddl.list.width("auto");
                        var panel = e.sender.element.parents(".b__panel,.b__popupeditorpanel");
                        if (panel.length > 0) {
                            var maxWidth = parseInt(panel.css("width").replace("px", ""));
                            ddl.list.css("max-width", maxWidth + "px");
                            lastColWidth = totalWidth > maxWidth ? 0 : maxWidth - totalWidth;
                            $(ddl.list).find("li span:not([style])").css("max-width", lastColWidth);
                        }
                        ddl.filterInput.off("keydown", null, function (e) { return _this.onKeyDownDropDownListFilter(e); });
                        ddl.filterInput.on("keydown", function (e) { return _this.onKeyDownDropDownListFilter(e); });
                        var span = $("#" + ddl.element.attr("id") + "-list>.k-list-filter>.k-i-zoom");
                        span.off("click", null, function (e) { return _this.onClickDropDownListFilter(e); });
                        span.on("click", function (e) { return _this.onClickDropDownListFilter(e); });
                    };
                    $(document).ready(this._globalDocumentReady);
                    $(document).ready(function () {
                        var headers = {};
                        headers['x-Requested-With'] = 'XMLHttpRequest';
                        var requestVerificationToken = $('input[name="__RequestVerificationToken"]').val();
                        if (requestVerificationToken != undefined)
                            headers['RequestVerificationToken'] = requestVerificationToken;
                        $.ajaxSetup({
                            xhrFields: {
                                withCredentials: true
                            },
                            headers: headers,
                            crossDomain: true,
                            cache: false,
                            traditional: true
                        });
                        var filterBtn = $('.cd-panel-content .b__filter--footer > .b__btn--high');
                        $(filterBtn).on('click', function (event) {
                            event.preventDefault();
                            $('.cd-panel').removeClass('is-visible');
                            $(".b__overlay").remove();
                            event.preventDefault();
                        });
                        $(document).ready(function () {
                            if ($(".b__footer--fixed-menu").length) {
                                $("main").css("margin-top", "145px");
                            }
                            $(".b__footer--fixed-menu").addClass("fixed-top");
                        });
                        $(document).on("scroll", function () {
                            if ($(".b__footer--fixed-menu").length && $(".b__footer--fixed-menu").css("display") !== 'none') {
                                if ($(document).scrollTop() > 50) {
                                    $(".b__header").addClass("tiny");
                                    $(".logomain").addClass("invisible");
                                    $(".menuTxt").removeClass("invisible");
                                    $(".topnav-right").addClass("invisible");
                                    $(".topnav-right").addClass("invisible");
                                    $(".b__footer--fixed-menu").addClass("footer-on-top");
                                    $(".b__quote--page--header").addClass("header-on-top");
                                }
                                else {
                                    $(".b__header").removeClass("tiny");
                                    $(".logomain").removeClass("invisible");
                                    $(".menuTxt").removeClass("tiny");
                                    $(".topnav-right").removeClass("invisible");
                                    $(".b__footer--fixed-menu").removeClass("footer-on-top");
                                    $(".b__quote--page--header").removeClass("header-on-top");
                                }
                            }
                        });
                        $(document).on('click', '.copy-text', function (e) {
                            e.preventDefault();
                            var copyText = $(this).text();
                            if ($(this).attr('id') == "brand-text") {
                                copyText = $('.copy-brand').text();
                            }
                            if ($(this).attr('id') == "model-text") {
                                copyText = $('.copy-model').text();
                            }
                            document.addEventListener('copy', function (e) {
                                e.clipboardData.setData('text/plain', copyText);
                                e.preventDefault();
                            }, true);
                            document.execCommand('copy');
                            $(this).attr("title", copyText);
                            $(".copied-tooltip").css("display", "block").delay(1000).fadeOut('slow');
                            ;
                        });
                        $(document).on('click', '.copy-all-text', function (e) {
                            e.preventDefault();
                            var copyText = $(".copy-text").text();
                            document.addEventListener('copy', function (e) {
                                e.clipboardData.setData('text/plain', copyText);
                                e.preventDefault();
                            }, true);
                            document.execCommand('copy');
                            $(this).attr("title", copyText);
                            $(".copied-tooltip").css("display", "block").delay(1000).fadeOut('slow');
                            ;
                        });
                        $(document).click(function () {
                            $(".quote-right-toolbar").removeClass("is-open");
                        });
                        $(document).on('click', '.quote-right-toolbar-toggle', function (e) {
                            $(".quote-right-toolbar").toggleClass("is-open");
                            e.stopPropagation();
                        });
                    });
                    if (!String.prototype.includes) {
                        String.prototype.includes = function (search, start) {
                            'use strict';
                            if (search instanceof RegExp) {
                                throw TypeError('first argument must not be a RegExp');
                            }
                            if (start === undefined) {
                                start = 0;
                            }
                            return this.indexOf(search, start) !== -1;
                        };
                    }
                    kendo.data.binders.widget.maskedValue = kendo.data.Binder.extend({
                        init: function (element, bindings, options) {
                            kendo.data.Binder.fn.init.call(this, element, bindings, options);
                            var that = this;
                            $(that.element.element).on("change", function () {
                                that.change();
                            });
                        },
                        refresh: function () {
                            this.element.value(this.bindings["maskedValue"].get());
                        },
                        change: function () {
                            this.bindings["maskedValue"].set(this.element.options.unmaskOnPost ? this.element.raw() : this.element.value());
                        }
                    });
                    $(document).ajaxError(function (event, request, settings) {
                        _this.hideLoadingSpinner();
                        _this.closeAllWindow();
                        var content = '';
                        if (request.responseJSON)
                            content = _this.createErrorString(request.responseJSON);
                        else
                            content = kendo.format('Hata! <br /> Url: {0} <br /> Hata Kodu: {1} <br /> İçerik: {2}', settings.url, request.status, request.statusText);
                        Dialog_1.Dialog.error(new Dialog_1.DialogOptions({
                            title: "Hata",
                            content: content
                        })).done(function (e) {
                            if (request.responseJSON.StatusCode == 401)
                                window.location.href = request.responseJSON.LogoutUrl;
                        });
                    });
                }
                Core.getInstance = function () {
                    return Core.instance;
                };
                Core.prototype.registerSignalRListener = function (listener) {
                    this.signaleRListeners.push(listener);
                };
                Core.prototype.unRegisterSignalRListener = function (listener) {
                    var index = this.signaleRListeners.indexOf(listener);
                    if (index >= 0) {
                        this.signaleRListeners.splice(index);
                    }
                };
                Core.prototype.dispatchSignalRMessage = function (message) {
                    this.signaleRListeners.forEach(function (listener) {
                        if (listener instanceof Bentas_1.ViewBase)
                            listener.signalRListener(message);
                        else
                            listener(message);
                    });
                };
                Core.prototype._globalDocumentReady = function () {
                    Date.prototype.toJSON = function () {
                        var timezoneOffsetInMinutes = ((-this.getTimezoneOffset()) % 60);
                        var timezoneOffsetInHours = (Math.floor((-this.getTimezoneOffset()) / 60));
                        var sign = timezoneOffsetInHours >= 0 ? '+' : '-';
                        var leadingMinutesZero = (timezoneOffsetInMinutes < 10) ? '0' : '';
                        var leadingHoursZero = (timezoneOffsetInHours < 10) ? '0' : '';
                        var correctedDate = new Date(this.getFullYear(), this.getMonth(), this.getDate(), this.getHours(), this.getMinutes(), this.getSeconds(), this.getMilliseconds());
                        correctedDate.setHours(this.getHours() + timezoneOffsetInHours);
                        correctedDate.setMinutes(this.getMinutes() + timezoneOffsetInMinutes);
                        var iso = correctedDate.toISOString().replace('Z', '');
                        return iso + sign + leadingHoursZero + Math.abs(timezoneOffsetInHours).toString() + ':' + leadingMinutesZero + Math.abs(timezoneOffsetInMinutes).toString();
                    };
                    (function () {
                        var ww = window;
                        if (typeof ww.CustomEvent === "function")
                            return false;
                        function CustomEvent(event, params) {
                            params = params || { bubbles: false, cancelable: false, detail: undefined };
                            var evt = document.createEvent('CustomEvent');
                            evt.initCustomEvent(event, params.bubbles, params.cancelable, params.detail);
                            return evt;
                        }
                        CustomEvent.prototype = ww.Event.prototype;
                        ww.CustomEvent = CustomEvent;
                    })();
                    $(document).on("click", function (e) {
                        $(".customColumnMenu").each(function (i, element) {
                            $(element).hide();
                        });
                    });
                    $('.b__header--item').click(function (e) {
                        var data = $(this).find(".b__header--item--panel");
                        data.toggle();
                        var childs = $('.b__header--item').find(".b__header--item--panel").not($(this).find(".b__header--item--panel"));
                        childs.css('display', 'none');
                        $("#cartNoDataContent").css('display', 'none');
                        e.stopPropagation();
                    });
                    $("#cart").click(function (e) {
                        $("#cartNoDataContent").toggle();
                        $('.b__header--item--panel').css('display', 'none');
                        e.stopPropagation();
                    });
                    $(document).click(function () {
                        $('.b__header--item--panel').css('display', 'none');
                        $("#cartNoDataContent").css('display', 'none');
                    });
                    $('#errorBox').click(function (e) {
                        if ($(".b__error--box").css('display') == 'none') {
                            var errorBoxHeight = $(".b__error--box").height();
                            var containerPadding = $(".b__container--pddng").css("padding-top");
                            var maxPadding = errorBoxHeight.toString() + parseInt(containerPadding);
                            $(".b__container--pddng").css("padding-top", maxPadding + 39);
                            $(".b__error--box").toggle();
                            e.stopPropagation();
                        }
                        else {
                            $(".b__error--box").toggle();
                            $(".b__container--pddng").css("padding-top", "80px");
                            e.stopPropagation();
                        }
                    });
                    $('#closeErrorBox').click(function () {
                        if ($(".b__error--box").css('display') == 'block') {
                            $(".b__error--box").toggle();
                            $(".b__container--pddng").css("padding-top", "80px");
                        }
                    });
                    $(document).click(function () {
                        if ($(".b__error--box").css('display') == 'block') {
                            $('.b__error--box').css('display', 'none');
                            $(".b__container--pddng").css("padding-top", "80px");
                        }
                    });
                    $(document).on('click', '.b__fixed--toolbar-close-button', function (e) {
                        $(".b__fixed--toolbar").animate({ right: "-=300" }, 200, function () { });
                        $(".b__fixed--toolbar-arrow").animate({ right: "+=300" }, 300, function () { });
                        e.preventDefault();
                    });
                    $(document).on('click', '.b__fixed--toolbar-arrow', function (e) {
                        $(".b__fixed--toolbar").animate({ right: "+=300" }, 200, function () { });
                        $(".b__fixed--toolbar-arrow").animate({ right: "-=300" }, 300, function () { });
                        e.preventDefault();
                    });
                    $(document).on('click', '.b__fixed--toolbar--button a:not(.b__icon-close)', function (event) {
                        event.preventDefault();
                        var h = $(this).attr('href');
                        if (h.indexOf("#") === 0) {
                            $('html, body').animate({
                                scrollTop: $(h).offset().top - 100
                            }, 500);
                        }
                    });
                    if ($(".b__mobile--nav").length > 0) {
                        new Menu_1.Menu().initMenu();
                    }
                    $(".b__header--item .b__header--item--panel ul.b__user--panel").click(function (e) { e.stopPropagation(); });
                    $(".b__content--wrapper").scroll(function () { $(document.body).find("[data-role=popup]").kendoPopup("close"); });
                    $("html").on("click", ".ripple, .b__btn, button, a.b__btn", function (evt) {
                        var btn = $(evt.currentTarget);
                        var x = evt.pageX - btn.offset().left;
                        var y = evt.pageY - btn.offset().top;
                        var duration = 400;
                        var animationFrame, animationStart;
                        var animationStep = function (timestamp) {
                            if (!animationStart) {
                                animationStart = timestamp;
                            }
                            var frame = timestamp - animationStart;
                            if (frame < duration) {
                                var easing = (frame / duration) * (2 - (frame / duration));
                                var circle = "circle at " + x + "px " + y + "px";
                                var color = "rgba(0, 0, 0, " + (0.2 * (1 - easing)) + ")";
                                var stop = 90 * easing + "%";
                                btn.css({
                                    "background-image": "radial-gradient(" + circle + ", " + color + " " + stop + ", transparent " + stop + ")"
                                });
                                animationFrame = window.requestAnimationFrame(animationStep);
                            }
                            else {
                                $(btn).css({
                                    "background-image": "none"
                                });
                                window.cancelAnimationFrame(animationFrame);
                            }
                        };
                        animationFrame = window.requestAnimationFrame(animationStep);
                    });
                    var dashboardNav = $(".slideout-sidebar");
                    var dashboardContent = $(".custom-dashboard .content-container");
                    $('.custom-dashboard .menu-icon').click(function (e) {
                        $(dashboardNav).toggleClass("is-open");
                        if ($(dashboardNav).hasClass("is-open")) {
                            $(dashboardContent).css("margin-left", "150px");
                        }
                        else {
                            $(dashboardContent).css("margin-left", "0");
                        }
                        e.stopPropagation();
                    });
                };
                Core.prototype.bind = function (element, viewModel) {
                    kendo.bind(element, viewModel);
                    this.refreshAllDropDownTexts();
                };
                Core.prototype.printDebugInfo = function () {
                    var args = [];
                    for (var _i = 0; _i < arguments.length; _i++) {
                        args[_i] = arguments[_i];
                    }
                    if (this.options.internalDebugInfo) {
                        console.log.apply(console, args);
                    }
                };
                Core.prototype.validator = function (e) {
                    if (e !== undefined) {
                        if (e.input.data("kendoDropDownList") !== undefined || e.input.data("kendoNumericTextBox") !== undefined) {
                            var span = $(e.input).parent();
                            if (!e.valid)
                                $(span).addClass("k-invalid");
                            else
                                $(span).removeClass("k-invalid");
                        }
                        else {
                            if (!e.valid)
                                $(e.input).addClass("k-invalid");
                            else
                                $(e.input).removeClass("k-invalid");
                        }
                    }
                };
                Core.prototype.replaceAll = function (s, search, replace) {
                    if (replace === undefined) {
                        return s;
                    }
                    return s.replace(new RegExp('' + search + '', 'g'), replace);
                };
                Core.prototype.formatString = function (str) {
                    var val = [];
                    for (var _i = 1; _i < arguments.length; _i++) {
                        val[_i - 1] = arguments[_i];
                    }
                    return kendo.format.apply(kendo, __spreadArray([str], val, false));
                };
                Core.prototype.onKeyDownDropDownListFilter = function (e) {
                    if (((e.ctrlKey || e.metaKey) && (e.keyCode == 10 || e.keyCode == 13)) || e.keyCode === 115) {
                        var id = $(e.target).parents(".k-list-filter").siblings(".k-list-md").attr("id");
                        id = id.substr(0, id.length - "-list".length);
                        var val = e.target.value;
                        if (!val || val === "") {
                            $("#" + id).data("kendoDropDownList")._clearFilter();
                        }
                        else {
                            $("#" + id).data("kendoDropDownList").search(val);
                        }
                    }
                    return true;
                };
                Core.prototype.onClickDropDownListFilter = function (e) {
                    var id = $(e.target).parents(".k-list-filter").siblings(".k-list-md").attr("id");
                    id = id.substr(0, id.length - "-list".length);
                    var val = $(e.target).prev().val();
                    if (!val || val === "") {
                        $("#" + id).data("kendoDropDownList")._clearFilter();
                    }
                    else {
                        $("#" + id).data("kendoDropDownList").search(val);
                    }
                    return true;
                };
                Core.prototype.refreshAllDropDownTexts = function () {
                    $("input[data-bentas-role='dropdownlist']").each(function (i, element) {
                        var ddl = $(element).data("kendoDropDownList");
                        if (ddl && ddl.options.valueTemplate) {
                            ddl.text(0);
                        }
                    });
                };
                Core.prototype.refreshDropDownText = function (element) {
                    var ddl = element.data("kendoDropDownList");
                    if (ddl && ddl.options.valueTemplate) {
                        ddl.text(0);
                    }
                };
                Core.prototype.hideColHeaders = function (id) {
                    var _this = this;
                    var grid = $("#" + id).data("kendoGrid");
                    var header = grid.thead;
                    header.addClass("k-grid-header");
                    header.appendTo(grid.table);
                    var colHeadId = id + "_colHead";
                    var jcolHeadId = "#" + colHeadId;
                    var div = $(jcolHeadId);
                    if (div.length) {
                        div.remove();
                    }
                    div = $("<div id=\"" + colHeadId + "\" style=\"display:none;\" class=\"customColumnMenu\"><table></table></div>").appendTo("#" + id);
                    var table = $(div).find("table");
                    header.appendTo(table);
                    var cols = $(header).find("tr>th");
                    for (var i = 0; i < cols.length; i++) {
                        header.append("<tr></tr>").append(cols[i]);
                    }
                    var columnButtonId = id + "_columnsMenuButton";
                    $("#" + columnButtonId).on("click", function (e) {
                        _this.hideAllColumnMenus();
                        var colHead = $(jcolHeadId);
                        if (colHead.css("display") === "none") {
                            colHead.css("display", "block");
                        }
                        else {
                            colHead.css("display", "none");
                        }
                        e.stopPropagation();
                    });
                };
                Core.prototype.hideAllColumnMenus = function () {
                    $(".customColumnMenu").each(function (i, element) {
                        $(element).hide();
                    });
                };
                Core.prototype.toStringWN = function (o, f) {
                    return kendo.toString(o === null ? "" : o, f);
                };
                Core.prototype.lookupFormat = function (o) {
                    return o === null || o === "0" || o === 0 ? "" : o;
                };
                Core.prototype.lookupFormat2 = function (id, field, textField, source) {
                    if (!source) {
                        source = $("#" + id).get(0).kendoBindingTarget.source;
                    }
                    var o1 = source.get ? source.get(field) : source[field];
                    if (o1 === null || o1 === "0" || o1 === 0)
                        return "";
                    if (source.get || source.hasOwnProperty(textField)) {
                        var o2 = source.get ? source.get(textField) : source[textField];
                        return "(" + o1 + ")" + (o2 === null ? "" : " " + o2);
                    }
                    else
                        return o1;
                };
                Core.prototype.validateDateInput = function (selector) {
                };
                Core.prototype.dateInputOnClick = function (selector) {
                };
                Core.prototype.setOnFocusForSelectAll = function (selector) {
                    $(document)
                        .on("focus", selector, function (evt) {
                        var input = $(evt.target);
                        clearTimeout(input.data("selectTimeId"));
                        var selectTimeId = setTimeout(function () {
                            input.select();
                        });
                        input.data("selectTimeId", selectTimeId);
                    })
                        .blur(function (e) {
                        clearTimeout($(e.target).data("selectTimeId"));
                    });
                };
                Core.prototype.gridFilterToolbarRefreshToggleStates = function (toolbarId, data) {
                    var toolbar = $("#" + toolbarId).data("kendoToolBar");
                    for (var index in toolbar.options.items) {
                        var item = toolbar.options.items[index];
                        if (item.type === "button" && item.togglable && item.field) {
                            if (data.hasOwnProperty(item.field)) {
                                toolbar.toggle("#" + item.id, data[item.field]);
                            }
                        }
                        else if (item.type === "buttonGroup") {
                            for (var index2 in item.buttons) {
                                var btn = item.buttons[index2];
                                if (btn.togglable && btn.field) {
                                    if (data.hasOwnProperty(btn.field)) {
                                        toolbar.toggle("#" + btn.id, data[btn.field]);
                                    }
                                }
                            }
                        }
                    }
                };
                Core.prototype.gridFilterToolbarOnToggle = function (gridId, data, e) {
                    var button;
                    for (var index in e.sender.options.items) {
                        var item = e.sender.options.items[index];
                        if (item.type === "button" && item.id === e.id) {
                            button = item;
                            break;
                        }
                        else if (item.type === "buttonGroup") {
                            for (var index2 in item.buttons) {
                                var item2 = item.buttons[index2];
                                if (item2.id === e.id) {
                                    button = item2;
                                    break;
                                }
                            }
                            if (button) {
                                break;
                            }
                        }
                    }
                    if (button && data.hasOwnProperty(button.field)) {
                        data.set(button.field, e.checked);
                        var grid = $("#" + gridId).data("kendoGrid");
                        grid.options.filtered = true;
                        grid.dataSource.read();
                    }
                };
                ;
                Core.prototype.gridOnError = function (e) {
                    e.sender.cancelChanges();
                };
                Core.prototype.getRowTemplate = function (templateId, gridId, hasDetail) {
                    var h = $('#' + templateId).html().trim();
                    if (h.toLowerCase().indexOf('<tr') !== 0) {
                        var tr = '<tr data-uid=\"#: data.uid #\" class="k-master-row" role="row">';
                        if (hasDetail) {
                            tr += "<td class='k-hierarchy-cell' aria-expanded='false'><a class='k-icon k-i-expand' href='\\#' tabindex='-1'></a></td>";
                        }
                        h = tr + '<td colspan=\"#: __colcount__ #\" class=\"b__clrpad-both\">' + h + '</td></tr>';
                    }
                    h = this.replaceAll(h, '__colcount__', '$(\"\\\\#' + gridId + '\").data(\"kendoGrid\").columns.length -($(\"\\\\#' + gridId + '\").data(\"kendoGrid\").options.detailTemplate?-1:0)');
                    return kendo.template(h, { useWithBlock: true });
                };
                Core.prototype.showLoadingSpinner = function (text) {
                    if (text === void 0) { text = undefined; }
                    var spinner = $("#loadingSpinner");
                    var innerText = "";
                    if (!this.isNullOrEmpty(text)) {
                        innerText = text;
                    }
                    if (spinner.length === 0) {
                        $("body").append("<div class='b__loading' id='loadingSpinner' style='display:none'><span class='b__text--color-orange b__bold--text b__font--size-6'>" + innerText + "</span></div>");
                        spinner = $("#loadingSpinner");
                    }
                    spinner.css("display", "block");
                };
                Core.prototype.hideLoadingSpinner = function () {
                    $("#loadingSpinner>span").text("");
                    $("#loadingSpinner").css("display", "none");
                };
                Core.prototype.openSlider = function (selector) {
                    $(selector).toggleClass("is-visible");
                    $("body").append("<div class='b__overlay' style='display: block'></div>");
                };
                Core.prototype.closeSlider = function (selector) {
                    $(selector).toggleClass("is-visible");
                    $(".b__overlay").remove();
                };
                Core.prototype.clearFilterObject = function (object, pristine) {
                    if (object && pristine) {
                        var unc = pristine._unClearableFields || [];
                        for (var item in pristine) {
                            if (!unc.includes(item) && object.hasOwnProperty(item)) {
                                if (object instanceof kendo.data.ObservableObject)
                                    object.set(item, pristine[item]);
                                else
                                    object[item] = pristine[item];
                            }
                        }
                    }
                };
                Object.defineProperty(Core.prototype, "parameters", {
                    get: function () {
                        var _this = this;
                        if (this.parameterList) {
                            return this.parameterList;
                        }
                        else {
                            $.ajax({
                                async: false,
                                url: "/Global/Parameters",
                                data: {},
                                success: function (response) {
                                    _this.parameterList = response;
                                }
                            });
                            return this.parameterList;
                        }
                    },
                    enumerable: false,
                    configurable: true
                });
                Core.prototype.createErrorString = function (errorJson) {
                    return kendo.format('Hata! <br /> Url: {0} <br /> Hata Kodu: {1} <br /> İçerik: {2} <br /> MessageId: {3} <br /> Program: {4}', errorJson.RequestUrl, errorJson.StatusCode, errorJson.Content, errorJson.MessageId, errorJson.AppName);
                };
                Core.prototype.closeAllWindow = function () {
                    this.hideLoadingSpinner();
                    $('.k-window-content:not(.k-dialog-content)').each(function (index) {
                        $(this).data("kendoWindow").close();
                    });
                };
                Core.prototype.addAntiForgeryTokens = function (param) {
                    return $.extend(true, {}, kendo.antiForgeryTokens(), param());
                };
                Core.prototype.combobox2OnChange = function () {
                    if (this.selectedIndex == -1 && this.value() != "") {
                        this.text(null);
                        this.value(null);
                        this.trigger("change");
                    }
                };
                Core.prototype.dtpOnChange = function () {
                    if (this.value() === null) {
                        this.value("");
                    }
                };
                Core.prototype.datePickerCheckValueOnFocusOut = function () {
                    $("input[data-role='datepicker']").on("focusout", function (e) {
                        if ($("#" + e.currentTarget.id).data("kendoDatePicker").value() === null) {
                            $("#" + e.currentTarget.id).data("kendoDatePicker").value("");
                        }
                    });
                };
                Core.prototype.dateTimePickerCheckValueOnFocusOut = function () {
                    $("input[data-role='datetimepicker']").on("focusout", function (e) {
                        if ($("#" + e.currentTarget.id).data("kendoDateTimePicker").value() === null) {
                            $("#" + e.currentTarget.id).data("kendoDateTimePicker").value("");
                        }
                    });
                };
                Core.prototype.isNullOrEmpty = function (value) {
                    return value == undefined || value == null || value == "";
                };
                Core.instance = new Core();
                return Core;
            }());
            exports_4("Core", Core);
        }
    };
});
System.register("Mobile", [], function (exports_5, context_5) {
    "use strict";
    var Mobile;
    var __moduleName = context_5 && context_5.id;
    return {
        setters: [],
        execute: function () {
            Mobile = (function () {
                function Mobile() {
                }
                Mobile.Android = function () {
                    return navigator.userAgent.match(/Android/i) !== null;
                };
                ;
                Mobile.BlackBerry = function () {
                    return navigator.userAgent.match(/BlackBerry/i) !== null;
                };
                ;
                Mobile.iOS = function () {
                    return navigator.userAgent.match(/iPhone|iPad|iPod/i) !== null;
                };
                ;
                Mobile.Opera = function () {
                    return navigator.userAgent.match(/Opera Mini/i) !== null;
                };
                ;
                Mobile.Windows = function () {
                    return navigator.userAgent.match(/IEMobile/i) !== null;
                };
                ;
                Mobile.Any = function () {
                    return (Mobile.Android() || Mobile.BlackBerry() || Mobile.iOS() || Mobile.Opera() || Mobile.Windows());
                };
                return Mobile;
            }());
            exports_5("Mobile", Mobile);
        }
    };
});
System.register("Print", [], function (exports_6, context_6) {
    "use strict";
    var PrintMode, PrintOptions, Print;
    var __moduleName = context_6 && context_6.id;
    return {
        setters: [],
        execute: function () {
            (function (PrintMode) {
                PrintMode[PrintMode["popup"] = 0] = "popup";
                PrintMode[PrintMode["iframe"] = 1] = "iframe";
            })(PrintMode || (PrintMode = {}));
            exports_6("PrintMode", PrintMode);
            PrintOptions = (function () {
                function PrintOptions(printMode, footer) {
                    this.printMode = PrintMode.popup;
                    this.footer = '';
                    if (printMode)
                        this.printMode = printMode;
                    if (footer)
                        this.footer = footer;
                }
                return PrintOptions;
            }());
            exports_6("PrintOptions", PrintOptions);
            Print = (function () {
                function Print() {
                }
                Print.printElement = function (selector, optionsOrMode) {
                    var options;
                    if (!optionsOrMode) {
                        options = new PrintOptions();
                    }
                    if (optionsOrMode instanceof PrintOptions) {
                        options = optionsOrMode;
                    }
                    else {
                        options = new PrintOptions(optionsOrMode);
                    }
                    var element = $(selector);
                    var scrolledElements = element.find(".mCustomScrollbar");
                    var mCustomScrollbars = [];
                    scrolledElements.each(function (index, item) {
                        mCustomScrollbars.push({ element: item, options: $.extend(true, {}, $(item).data().mCS.opt) });
                        $(item).mCustomScrollbar("destroy");
                    });
                    if (options.printMode === PrintMode.popup) {
                        Print.printHtmlPopUp(element.html(), options.footer);
                    }
                    else {
                        Print.printHtmlIFrame(element.html(), options.footer);
                    }
                    scrolledElements.each(function (index, item) {
                        $(item).mCustomScrollbar(mCustomScrollbars[index].options);
                    });
                };
                Print.prepareHtml = function (data, footer) {
                    var html = '<html><head><title>Page Title</title>';
                    var cssList = $("link[rel='stylesheet']");
                    for (var i = 0; i < cssList.length; i++) {
                        var css = cssList.get(i).href;
                        if (css.indexOf("mCustomScrollbar") == -1)
                            html += '<link href="' + css + '" rel="stylesheet">';
                    }
                    if (footer)
                        html += '</head><body><table><tbody><tr><td>' + data + '</td></tr></tbody><tfoot><tr><td><div class="page-footer-space"></div></td></tr></tfoot></table><div class="page-footer">' + footer + '</div><script>function printPage(popup){focus();print();if (popup) close();}</script></body></html>';
                    else
                        html += '</head><body>' + data + '<script>function printPage(popup){focus();print();if (popup) close();}</script></body></html>';
                    return html;
                };
                Print.printHtmlPopUp = function (data, footer) {
                    var mywindow = window.open('', '', 'height=700,width=800');
                    mywindow.document.open();
                    mywindow.document.write(Print.prepareHtml(data, footer));
                    $(mywindow.document).find(".b__window--button-group").remove();
                    mywindow.document.close();
                    mywindow.focus = function () { setTimeout(function () { window.close(); }, 50); };
                    Print.callPrint(mywindow, true);
                    return true;
                };
                Print.printHtmlIFrame = function (data, footer) {
                    $("[id^='bentas_print_iframe_']").remove();
                    var iframeID = "bentas_print_iframe_" + (Math.round(Math.random() * 99999)).toString();
                    var iframe = document.createElement('IFRAME');
                    $(iframe).attr({
                        style: 'border:none;position:absolute;width:0px;height:0px;bottom:0px;left:0px;',
                        id: iframeID,
                        frameBorder: 0,
                        scrolling: 'no',
                        src: 'about:blank'
                    });
                    document.body.appendChild(iframe);
                    var iframeDocument = (iframe.contentWindow || iframe.contentDocument);
                    if (iframeDocument.document)
                        iframeDocument = iframeDocument.document;
                    iframeDocument.open();
                    iframeDocument.write(Print.prepareHtml(data, footer));
                    iframeDocument.close();
                    iframe = (document.frames ? document.frames[iframeID] : document.getElementById(iframeID));
                    var wnd = iframe.contentWindow || iframe;
                    Print.callPrint(wnd, false);
                    return true;
                };
                Print.callPrint = function (element, popup) {
                    if (element && element["printPage"])
                        element["printPage"](popup);
                    else
                        setTimeout(function () { Print.callPrint(element, popup); }, 50);
                };
                ;
                return Print;
            }());
            exports_6("Print", Print);
        }
    };
});
System.register("Window", ["Core"], function (exports_7, context_7) {
    "use strict";
    var Core_2, ActiveWindow, WindowOptions, Window;
    var __moduleName = context_7 && context_7.id;
    return {
        setters: [
            function (Core_2_1) {
                Core_2 = Core_2_1;
            }
        ],
        execute: function () {
            ActiveWindow = (function () {
                function ActiveWindow(window) {
                    this.window = window;
                }
                return ActiveWindow;
            }());
            exports_7("ActiveWindow", ActiveWindow);
            WindowOptions = (function () {
                function WindowOptions(init) {
                    this.title = document.title;
                    this.modal = true;
                    this.draggable = true;
                    this.visible = false;
                    this.animation = false;
                    this.minimize = false;
                    if (init) {
                        this.title = init.title;
                        this.content = init.content;
                        this.modal = init.modal === false ? false : true;
                        this.draggable = init.draggable === false ? false : true;
                        this.visible = init.visible === true ? init.visible : false;
                        this.minimize = init.visible === true ? init.visible : false;
                        this.open = init.open;
                        this.close = init.close;
                        this.width = init.width;
                        this.height = init.height;
                    }
                }
                return WindowOptions;
            }());
            exports_7("WindowOptions", WindowOptions);
            Window = (function () {
                function Window() {
                }
                Window.open = function (paramOrTitle, content, modal) {
                    var kendoOptions = (new Object());
                    var param;
                    var core = Core_2.Core.getInstance();
                    var defaultWidth = 200;
                    if (paramOrTitle instanceof WindowOptions) {
                        param = paramOrTitle;
                    }
                    else {
                        param = new WindowOptions();
                        param.title = paramOrTitle;
                        param.content = content;
                        if (modal === undefined)
                            modal = true;
                        param.modal = modal;
                        param.visible = true;
                    }
                    kendoOptions.title = param.title;
                    kendoOptions.modal = param.modal;
                    kendoOptions.visible = param.visible;
                    kendoOptions.draggable = param.draggable;
                    if (param.width)
                        kendoOptions.width = param.width;
                    else
                        kendoOptions.width = defaultWidth;
                    if (param.height)
                        kendoOptions.height = param.height;
                    if (!param.content)
                        param.content = "";
                    var wContent = param.content.parent ? "" : param.content;
                    var wContentElement = param.content.parent ? param.content : undefined;
                    var wContentElementParent = undefined;
                    if (wContentElement)
                        wContentElementParent = wContentElement.parent();
                    kendoOptions.open = function (e) {
                        $("body, html ").css("overflow", "hidden");
                        if (param.modal)
                            Window.activeWindow = new ActiveWindow(e.sender);
                        if (wContentElement) {
                            wContentElement.removeAttr("style").appendTo(e.sender.wrapper.find(".k-window-content"));
                        }
                        if (param.open) {
                            param.open(e);
                        }
                        core.refreshAllDropDownTexts();
                    };
                    kendoOptions.close = function (e) {
                        $("body, html ").css("overflow", "");
                        core.printDebugInfo("bentas.Window.onclose", e);
                        if (param && param.close) {
                            param.close(e);
                        }
                        if (!e.isDefaultPrevented()) {
                            if (wContentElement) {
                                wContentElement.attr("style", "display:none;").appendTo(wContentElementParent);
                            }
                            $("#bentas-window-open").remove();
                            e.sender.result.resolve(Window.activeWindow);
                            if (param.modal)
                                Window.activeWindow = undefined;
                        }
                    };
                    var wnd = $("<div id='bentas-window-open'></div>").appendTo("body").html(wContent).kendoWindow(kendoOptions).data("kendoWindow").center().open();
                    wnd.result = $.Deferred();
                    return wnd.result;
                };
                ;
                Window.activeWindow = undefined;
                return Window;
            }());
            exports_7("Window", Window);
        }
    };
});
System.register("FindDialog", ["Dialog"], function (exports_8, context_8) {
    "use strict";
    var Dialog_2, FindDialog;
    var __moduleName = context_8 && context_8.id;
    return {
        setters: [
            function (Dialog_2_1) {
                Dialog_2 = Dialog_2_1;
            }
        ],
        execute: function () {
            FindDialog = (function () {
                function FindDialog() {
                }
                FindDialog.open = function (params) {
                    var result = $.Deferred();
                    var orjReadData = params.dataSource.transport.read.data;
                    params.dataSource.transport.read.data = function () {
                        var data;
                        if (orjReadData) {
                            if (orjReadData instanceof Function)
                                data = orjReadData();
                            else
                                data = orjReadData;
                        }
                        else
                            data = params.params;
                        return data;
                    };
                    var gridContainerElement = $("<div style=\"display:none; height: 100%\"></div>");
                    var id = kendo.guid();
                    var gridElement = $("<div id=\"".concat(id, "\" class=\"b__dialog--grid\"></div>"));
                    var toolbarElement = $("<div class=\"b__dialog--toolbar\"><div class=\"b__dialog--toolbar--btn-filter\" title = \"Filtrele\"><i class=\"b__icon-filter\"></i></div><div class=\"b__dialog--toolbar--btn-clear-filter\" title = \"Filitreyi Temizle\"><i class=\"b__icon-filter-remove\"></i></div></div>");
                    toolbarElement.appendTo(gridContainerElement);
                    gridElement.appendTo(gridContainerElement);
                    gridContainerElement.appendTo("body");
                    var columns = params.columns.slice(0);
                    for (var colIndex in columns) {
                        if (columns[colIndex].width) {
                            delete columns[colIndex].width;
                        }
                    }
                    if (params.multiSelect) {
                        columns.unshift({ selectable: true, width: 35 });
                    }
                    else {
                        columns.unshift({ title: "", width: 35, template: "<i class=\"b__icon-file-document-box-check-outline b__dialog--grid--icon\"></i>" });
                    }
                    var grid = gridElement.kendoGrid({
                        sortable: true,
                        scrollable: true,
                        reorderable: true,
                        resizable: true,
                        selectable: "row",
                        dataSource: params.dataSource,
                        columns: columns,
                        dataBound: function (e) {
                            $(".k-dialog .k-filtercell .k-button").remove();
                            $(".k-dialog .k-filtercell input[data-bind]").unbind("keydown");
                            $(".k-dialog .k-filtercell input[data-bind]").bind("keydown", function (e) {
                                if (e.ctrlKey && e.keyCode === 13) {
                                    if ($(e.target).data("kendoDatePicker"))
                                        $(e.target).data("kendoDatePicker")._change($(e.target).val());
                                    FindDialog.setFilter(grid);
                                }
                            });
                        },
                        filterable: {
                            mode: "row"
                        },
                        pageable: {
                            pageSize: 100,
                            refresh: true,
                        },
                        noRecords: {
                            template: "<div class=\"empty-grid\"></div>",
                        },
                        excel: {
                            allPages: true
                        },
                        pdf: {
                            allPages: true
                        },
                        filter: function (e) {
                            e.preventDefault();
                        }
                    }).data("kendoGrid");
                    var dialog;
                    var dialogOptions = new Dialog_2.DialogOptions({
                        buttons: params.multiSelect ?
                            [new Dialog_2.DialogButton({
                                    text: params.okTitle, default: true, onclick: function () {
                                        if (grid.select().length === 0) {
                                            Dialog_2.Dialog.errorTitle(params.title, params.errors[0]);
                                            return false;
                                        }
                                        else
                                            return true;
                                    }
                                }),
                                params.cancelTitle] : [params.cancelTitle],
                        content: gridContainerElement,
                        height: window.innerHeight * 0.90,
                        width: window.innerWidth * 0.90,
                        title: params.title,
                        open: function (e, dlg) {
                            dialog = dlg;
                        }
                    });
                    Dialog_2.Dialog.confirmation(dialogOptions)
                        .done(function (dialogResult) {
                        var resultData = undefined;
                        if (dialogResult && dialogResult.index === 0) {
                            params.dataSource.transport.read.data = orjReadData;
                            var selectedRows = grid.select();
                            if (selectedRows.length > 0) {
                                if (params.multiSelect) {
                                    resultData = [];
                                    selectedRows.each(function (index, row) {
                                        resultData.push(grid.dataItem(row).toJSON());
                                    });
                                }
                                else {
                                    resultData = grid.dataItem(selectedRows.get(0)).toJSON();
                                }
                            }
                        }
                        gridContainerElement.remove();
                        return result.resolve(resultData);
                    });
                    gridElement.on("click", ".b__dialog--grid--icon", function (e) {
                        grid.select($(e.target).parents("tr"));
                        dialog.options.actions[0].action(dialog.options.actions[0]);
                        dialog.close();
                    });
                    gridContainerElement.on("click", ".b__icon-filter", function (e) {
                        FindDialog.setFilter(grid);
                    });
                    gridContainerElement.on("click", ".b__icon-filter-remove", function (e) {
                        FindDialog.clearFilter(grid);
                    });
                    return result;
                };
                FindDialog.clearFilter = function (grid) {
                    grid.dataSource.filter({});
                };
                FindDialog.setFilter = function (grid) {
                    var filters = new Array();
                    grid.thead.find(".k-filtercell input[data-bind]").each(function (index, element) {
                        var val = $(element).data("handler") ? $(element).data("handler").value() : $(element).val();
                        if (val) {
                            var field = $(element).parents("span[data-field]").attr("data-field");
                            var operator = "eq";
                            if (grid.dataSource.options.schema.model.fields[field].type === "number") {
                                val = isNaN(Number(val)) ? null : Number(val);
                            }
                            filters.push({ operator: operator, value: val, field: field });
                        }
                    });
                    grid.dataSource.filter(filters);
                };
                return FindDialog;
            }());
            exports_8("FindDialog", FindDialog);
        }
    };
});
System.register("ViewBase", ["Core", "Observable", "FindDialog", "Dialog"], function (exports_9, context_9) {
    "use strict";
    var Core_3, Observable_1, FindDialog_1, Dialog_3, ViewBase;
    var __moduleName = context_9 && context_9.id;
    return {
        setters: [
            function (Core_3_1) {
                Core_3 = Core_3_1;
            },
            function (Observable_1_1) {
                Observable_1 = Observable_1_1;
            },
            function (FindDialog_1_1) {
                FindDialog_1 = FindDialog_1_1;
            },
            function (Dialog_3_1) {
                Dialog_3 = Dialog_3_1;
            }
        ],
        execute: function () {
            ViewBase = (function () {
                function ViewBase() {
                    this.core = Core_3.Core.getInstance();
                    this.data = undefined;
                    this.localizer = undefined;
                    this.core.registerSignalRListener(this);
                }
                ViewBase.prototype.signalRListener = function (messsage) {
                };
                ViewBase.prototype.observable = function (data) {
                    return new Observable_1.Observable().observable(data);
                };
                ViewBase.prototype.documentReady = function () {
                };
                ViewBase.prototype.bind = function () {
                };
                ViewBase.prototype.findElement = function (id) {
                    if (id.indexOf("#") === 0)
                        id = id.substring(1);
                    return $("#" + id);
                };
                ViewBase.prototype.getDropDownList = function (id) {
                    return this.findElement(id).data("kendoDropDownList");
                };
                ViewBase.prototype.getDropDownListDataSource = function (id) {
                    return this.getDropDownList(id).dataSource;
                };
                ViewBase.prototype.getGrid = function (id) {
                    return this.findElement(id).data("kendoGrid");
                };
                ViewBase.prototype.replaceInstanceName = function (content, isCompoentModule) {
                    if (isCompoentModule === void 0) { isCompoentModule = false; }
                    content = !content ? content : content.replace(new RegExp(/\$page\$/g), this.instanceName).replace(/\$page_forid\$/g, isCompoentModule ? this.instanceName + "_" : "");
                    return content;
                };
                ViewBase.prototype.findDialog = function (dialogId, fieldMaps, data) {
                    var innerData = this.data;
                    var maps;
                    var modelData = innerData;
                    if (data) {
                        if (typeof data === "string") {
                            if ($(data).data("kendoGrid")) {
                                modelData = $(data).data("kendoGrid").options.filtervm;
                            }
                        }
                        else {
                            modelData = data;
                        }
                    }
                    if (fieldMaps instanceof Array) {
                        maps = fieldMaps;
                    }
                    else {
                        maps = this.core.replaceAll(fieldMaps, ",", ";").split(";");
                    }
                    if (innerData && innerData._find[dialogId]) {
                        if (innerData._find[dialogId].multiSelect) {
                            Dialog_3.Dialog.error(innerData._find[dialogId].errors[1]);
                            return;
                        }
                        var result_1 = $.Deferred();
                        FindDialog_1.FindDialog.open(innerData._find[dialogId])
                            .done(function (e) {
                            if (e) {
                                for (var prop in maps) {
                                    var map = maps[prop];
                                    var toField = map;
                                    var fromField = map;
                                    if (map.indexOf("=") > 0) {
                                        toField = map.split("=")[0];
                                        fromField = map.split("=")[1];
                                    }
                                    if (modelData instanceof kendo.data.ObservableObject)
                                        modelData.set(toField, e[fromField]);
                                    else
                                        modelData[toField] = e[fromField];
                                }
                            }
                            result_1.resolve(e);
                        });
                        return result_1;
                    }
                };
                return ViewBase;
            }());
            exports_9("ViewBase", ViewBase);
        }
    };
});
System.register("DynamicView", ["ViewBase", "Dialog", "Window", "Mobile"], function (exports_10, context_10) {
    "use strict";
    var ViewBase_1, Dialog_4, Window_1, Mobile_1, DynamicView, DynamicViewEntity, Component, ComponentInstance, ComponentInstanceParam, containerHTML;
    var __moduleName = context_10 && context_10.id;
    return {
        setters: [
            function (ViewBase_1_1) {
                ViewBase_1 = ViewBase_1_1;
            },
            function (Dialog_4_1) {
                Dialog_4 = Dialog_4_1;
            },
            function (Window_1_1) {
                Window_1 = Window_1_1;
            },
            function (Mobile_1_1) {
                Mobile_1 = Mobile_1_1;
            }
        ],
        execute: function () {
            DynamicView = (function (_super) {
                __extends(DynamicView, _super);
                function DynamicView() {
                    var _this = _super.call(this) || this;
                    _this.components = new Array();
                    _this.componentInstances = new Array();
                    _this.bentasViewTagName = "bentas-viewmodel";
                    _this.createEmptyContainerInstance = function (moduleName, controllerName, componentName) {
                        var filter = _this.components.filter(function (c) { return c.ModuleName === moduleName && c.ControllerName === controllerName && c.Name === componentName; });
                        if (filter.length === 1) {
                            var comp = filter[0];
                            if (comp.ParameterComponent && _this.componentInstances.filter(function (i) { return i.ParameterComponent; }).length !== 0) {
                                Dialog_4.Dialog.errorTitle(_this.localizer["Hata"], _this.localizer["Bir görünümde sadece tek bir parametre componenti olabilir !"]);
                                return;
                            }
                            var param = new ComponentInstanceParam();
                            param.ModuleName = moduleName;
                            param.ControllerName = controllerName;
                            param.Name = componentName;
                            _this.createContainerInstance(param);
                        }
                    };
                    _this.createContainerInstance = function (param) {
                        var component = _this.components.filter(function (component) { return component.ModuleName === param.ModuleName && component.ControllerName === param.ControllerName && component.Name === param.Name; })[0];
                        var containerInstance = new ComponentInstance();
                        containerInstance.ModuleName = param.ModuleName;
                        containerInstance.ControllerName = param.ControllerName;
                        containerInstance.Name = param.Name;
                        containerInstance.Title = component.Title;
                        containerInstance.ComponentID = param.ComponentID ? param.ComponentID : kendo.guid();
                        containerInstance.SettingsAvailable = component.SettingsAvailable;
                        containerInstance.RefreshAvailable = component.RefreshAvailable;
                        containerInstance.InfoAvailable = component.InfoAvailable;
                        containerInstance.ParameterComponent = component.ParameterComponent;
                        containerInstance.PrivateComponent = component.PrivateComponent;
                        containerInstance.ProjectUrl = component.ProjectUrl;
                        containerInstance.CssClasses = component.CssClasses;
                        _this.componentInstances.push(containerInstance);
                        var html = _this.componentTemplate(containerInstance);
                        var containerInstanceElement;
                        if (containerInstance.ParameterComponent) {
                            containerInstanceElement = "<div class='new-db-param-info'><div></div> <span><a href='##' class='db-filter'><i class='b__icon-filter-variant'></i></a></span>  </div> <div class='cd-panel-db from-right'> <div class='cd-panel-container-db'>  <div class='cd-panel-close-db'><a role='button' href='#' class='k-button k-flat k-button-icon' ><span class='k-icon k-i-close''></span></a></div> <div class='cd-panel-content-db'>" + html + " </div></div></div>";
                            $(".b__dashboard--section").prepend(containerInstanceElement);
                            $(".cd-panel-content-db>div").get(0).addEventListener("refeshComponent", _this.refreshComponentEventHandler);
                            _this.refreshContainerInstance(containerInstance.ComponentID, param.Data);
                            _this.prepareHover();
                        }
                        else {
                            if (param.ComponentID) {
                                containerInstanceElement = _this.gridstack.addWidget($(html), param.Col, param.Row, param.Width, param.Height);
                            }
                            else {
                                containerInstanceElement = _this.gridstack.addWidget($(html), 0, 0, component.Width, component.Height, true);
                            }
                            if (!containerInstance.SettingsAvailable) {
                                containerInstanceElement.find(".b__dashboard--settings-button").remove();
                            }
                            if (!containerInstance.RefreshAvailable) {
                                containerInstanceElement.find(".b__dashboard--refresh-button").remove();
                            }
                            containerInstance.GridNode = containerInstanceElement.data("_gridstack_node");
                            containerInstanceElement.get(0).addEventListener("refeshComponent", _this.refreshComponentEventHandler);
                            _this.refreshContainerInstance(containerInstance.ComponentID, param.Data);
                            _this.prepareHover();
                        }
                    };
                    _this.refreshComponentEventHandler = function (e) {
                        var id = e.currentTarget.id;
                        var containerInstance = _this.componentInstances.filter(function (containerInstance) { return containerInstance.ComponentID === id; })[0];
                        var component = _this.components.filter(function (component) { return component.ModuleName === containerInstance.ModuleName && component.ControllerName === containerInstance.ControllerName && component.Name === containerInstance.Name; })[0];
                        var containerInstanceElement = $("#" + id);
                        var viewInstanceName = containerInstanceElement.find(_this.bentasViewTagName).attr("id");
                        var viewInstance = window[viewInstanceName];
                        var containerInstanceElementContent = containerInstanceElement.find(".b__dashboard--panel--content");
                        var data;
                        if (viewInstance && !e.detail.datastr)
                            data = viewInstance.filterData();
                        else
                            data = !e.detail.datastr ? {} : JSON.parse(e.detail.datastr);
                        containerInstanceElementContent.html("<div class='b__loading-mini'><img src='/Images/FrameWork/Bentas/Loaders/Ripple.gif'/></div>");
                        if (viewInstance)
                            _this.disposeViewInstance(viewInstanceName);
                        var headers = {};
                        if (component.Method === "POST") {
                            headers = { 'Accept': 'application/json', 'Content-Type': 'application/json', 'x-Requested-With': 'XMLHttpRequest' };
                        }
                        component.ProjectUrl = component.ProjectUrl.endsWith('/') ? component.ProjectUrl : component.ProjectUrl + "/";
                        var url;
                        if (data && data.SirketKavNo !== undefined) {
                            url = component.ProjectUrl + "s/" + data.SirketKavNo + "/" + component.ControllerName.replace("Controller", "") + "/" + component.Name;
                        }
                        else {
                            url = component.ProjectUrl + component.ControllerName.replace("Controller", "") + "/" + component.Name;
                        }
                        $.ajax({
                            url: url,
                            headers: headers,
                            method: component.Method,
                            data: data,
                            error: function (jqXHR, textStatus, errorThrown) {
                                containerInstanceElementContent.html(errorThrown);
                            },
                            success: function (response) {
                                containerInstanceElementContent.html(response);
                            }
                        });
                    };
                    _this.callComponentInstanceSettings = function (id) {
                        var containerInstanceElement = $("#" + id);
                        var viewInstanceName = containerInstanceElement.find(_this.bentasViewTagName).attr("id");
                        if (viewInstanceName)
                            window[viewInstanceName].settings(containerInstanceElement).always(function () { _this.refreshContainerInstance(id); });
                    };
                    _this.removeComponentInstance = function (id) {
                        var containerInstance = _this.componentInstances.filter(function (containerInstance) { return containerInstance.ComponentID === id; })[0];
                        _this.componentInstances.splice(_this.componentInstances.indexOf(containerInstance), 1);
                        var containerInstanceElement = $("#" + id);
                        var viewInstanceName = containerInstanceElement.find(_this.bentasViewTagName).attr("id");
                        _this.gridstack.removeWidget(containerInstanceElement);
                        if (viewInstanceName)
                            _this.disposeViewInstance(viewInstanceName);
                    };
                    _this.core.options.internalDebugInfo = false;
                    return _this;
                }
                DynamicView.prototype.bind = function () {
                    $("#viewsBigMenuKeyDescription").text(this.data.KeyDescription);
                };
                DynamicView.prototype.documentReady = function () {
                    var _this = this;
                    $("#" + this.instanceName).append(this.core.replaceAll(containerHTML, "\\$page\\$", this.instanceName));
                    $("#lcSistem").text(this.localizer["Sistem"]);
                    $("#lcKullanici").text(this.localizer["Kullanıcı"]);
                    $("#lcYeniGorunum").attr("title", this.localizer["Yeni Görünüm"]);
                    $("#lcKaydet").attr("title", this.localizer["Kaydet"]);
                    $("#lcFarkliKaydet").attr("title", this.localizer["Farklı Kaydet"]);
                    $("#lcGorunumuSil").attr("title", this.localizer["Görünümü Sil"]);
                    $("#lcKapat").attr("title", this.localizer["Kapat"]);
                    $("#lcParametreler").attr("title", this.localizer["Parametreler"]);
                    $("#lcGenel").attr("title", this.localizer["Özel"]);
                    $("#lcOzel").attr("title", this.localizer["Genel"]);
                    $(window).resize(function () {
                        kendo.resize($("div.k-chart[data-role='chart']"), false);
                    });
                    this.gridstack = $(".grid-stack").gridstack({
                        handleClass: "b__dashboard--panel--header",
                        cellHeight: 30,
                        verticalMargin: 10,
                        horizontalMargin: 10,
                        alwaysShowResizeHandle: false,
                        resizable: {
                            handles: 'e, se, s, sw, w'
                        }
                    }).data("gridstack");
                    this.componentTemplate = kendo.template($("#component-template").html());
                    this.componentListItemTemplate = kendo.template($("#component-list-item-template").html());
                    this.getComponentList();
                    this.prepareViewsMenu();
                    $("li[for='" + this.data.ActiveView.Name + "']").addClass("k-state-active");
                    $('.grid-stack').on('gsresizestop', function () {
                        var filterContainer = $(".b__dashboard--filter > .b__row > [class*='b__']");
                        if (filterContainer.parents('.grid-stack-item').width() < 768) {
                            $(filterContainer).addClass('b__12');
                        }
                        else {
                            $(filterContainer).removeClass('b__12');
                        }
                    });
                    $(document).click(function () {
                        $(".new-db-toolbar").removeClass("is-open");
                    });
                    $('.new-db-toolbar-toggle').click(function (e) {
                        $(".new-db-toolbar").toggleClass("is-open");
                        e.stopPropagation();
                    });
                    $("main").css("padding-top", "55px");
                    $(document).on('click', '.db-filter', function (event) {
                        event.preventDefault();
                        $('.cd-panel-db').addClass('is-visible');
                        $('.custom-dashboard .b__dashboard--header').css('position', 'static');
                    });
                    $(document).on('click', '.cd-panel-close-db', function (event) {
                        $('.cd-panel-db').removeClass('is-visible');
                        $('.custom-dashboard .b__dashboard--header').css('position', 'sticky');
                        event.preventDefault();
                        event.stopPropagation();
                    });
                    this.tooltip = $("body").kendoTooltip({
                        autoHide: false,
                        showOn: "click",
                        position: "bottom",
                        filter: ".componentInfoButton",
                        content: function (e) {
                            var id = $(e.target).parents(".grid-stack-item").find(_this.bentasViewTagName).attr("id");
                            var html = $("#" + id + "_info").html();
                            return html || "Komponent yardımı bulunamadı. Lütfen Bentaş ile irtibata geçin !";
                        }
                    }).data("kendoTooltip");
                };
                DynamicView.prototype.prepareViewsMenu = function () {
                    var _this = this;
                    var accessibleViews = this.data.AccessibleViews.data();
                    var menuItemTemplate = kendo.template($("#view-menuitem-template").html());
                    accessibleViews.forEach(function (view) {
                        $("#tabstrip > ul").append(menuItemTemplate({ caption: view.Name, url: _this.combineRootUrl("Index/" + view.DynamicViewID.toString()), publicView: view.PublicView }));
                    });
                    $("#tabstrip").kendoTabStrip({
                        animation: {
                            open: {
                                effects: "fadeIn"
                            }
                        }
                    });
                };
                DynamicView.prototype.prepareHover = function () {
                    if (!Mobile_1.Mobile.Any()) {
                        $(".b__dashboard--panel--header").find(".b__dashboard--panel--header-right").find("a").css("display", "none");
                        $(document).off("mouseover", ".b__dashboard--panel--header", false);
                        $(document).off("mouseleave", ".b__dashboard--panel--header", false);
                        $(document).on("mouseover", ".b__dashboard--panel--header", function (e) {
                            $(e.target).find(".b__dashboard--panel--header-right").find("a").css("display", "block");
                        });
                        $(document).on("mouseleave", ".b__dashboard--panel--header", function (e) {
                            $(e.target).find(".b__dashboard--panel--header-right").find("a").css("display", "none");
                        });
                    }
                    else {
                        $(".b__dashboard--panel--header").find(".b__dashboard--panel--header-right").find("a").css("display", "block");
                    }
                };
                DynamicView.prototype.getComponentList = function () {
                    var _this = this;
                    $.ajax({
                        url: this.combineRootUrl("GetComponentList"),
                        data: {},
                        success: function (response) {
                            _this.components = response;
                            var parameterComponentsHtml = "";
                            var privateComponentsHtml = "";
                            var generalComponentsHtml = "";
                            for (var index in _this.components) {
                                var component = _this.components[index];
                                if (component.ParameterComponent) {
                                    parameterComponentsHtml += _this.componentListItemTemplate(component);
                                }
                                else if (component.PrivateComponent) {
                                    privateComponentsHtml += _this.componentListItemTemplate(component);
                                }
                                else
                                    generalComponentsHtml += _this.componentListItemTemplate(component);
                            }
                            $("#componentListParametre").html(parameterComponentsHtml);
                            $("#componentListOzel").html(privateComponentsHtml);
                            $("#componentListGenel").html(generalComponentsHtml);
                            _this.getView();
                        }
                    });
                };
                DynamicView.prototype.getView = function () {
                    var _this = this;
                    $.ajax({
                        url: this.combineRootUrl("GetView"),
                        data: { id: this.data.ActiveView.DynamicViewID },
                        success: function (response) {
                            var components = response;
                            var _loop_1 = function (index) {
                                var component = components[index];
                                if (_this.components.filter(function (c) { return c.ModuleName === component.ModuleName && c.ControllerName === component.ControllerName && c.Name === component.Name; }).length != 0) {
                                    _this.createContainerInstance(component);
                                }
                            };
                            for (var index in components) {
                                _loop_1(index);
                            }
                        }
                    });
                };
                DynamicView.prototype.showSaveDialog = function (saveAs) {
                    var _this = this;
                    if (!saveAs && this.data.ActiveView.PublicView && !this.data.IsRootAdmin) {
                        Dialog_4.Dialog.errorTitle(this.localizer["Hata"], this.localizer["Sistem görünümlerini sadece yönetici değiştirebilir !"]);
                        return;
                    }
                    var viewEntity = this.data.ActiveView;
                    if (saveAs) {
                        viewEntity = new DynamicViewEntity();
                        viewEntity.DynamicViewID = -1;
                        viewEntity.Name = "";
                        viewEntity.DefaultView = false;
                        viewEntity.PublicView = false;
                    }
                    Dialog_4.Dialog.confirmation(new Dialog_4.DialogOptions({
                        title: this.localizer["Görünüm Kaydet"],
                        content: $("#save-dialog-template").html().replace("lcAciklama", this.localizer["Açıklama"]).replace("lcGenelGorunum", this.localizer["Genel Görünüm"]).replace("lcVarsayilanGorunum", this.localizer["Varsayılan Görünüm"]),
                        buttons: [this.localizer["Kaydet"], this.localizer["Vazgeç"]],
                        open: function () {
                            $("#saveDialogName").val(viewEntity.Name);
                            $("#saveDialogPublicView").prop("checked", viewEntity.PublicView);
                            $("#saveDialogDefaultView").prop("checked", viewEntity.DefaultView);
                            if (!_this.data.IsRootAdmin) {
                                $("#saveDialogPublicView").remove();
                                $("#saveDialogPublicViewLabel").remove();
                            }
                        }
                    }))
                        .done(function (result) {
                        if (result && result.index === 0) {
                            viewEntity.Name = $("#saveDialogName").val().toString();
                            viewEntity.PublicView = $("#saveDialogPublicView").is(":checked");
                            viewEntity.DefaultView = $("#saveDialogDefaultView").is(":checked");
                            _this.saveView(viewEntity);
                        }
                    });
                };
                DynamicView.prototype.saveView = function (viewEntity) {
                    var _this = this;
                    var components = new Array();
                    this.componentInstances.forEach(function (containerInstance) {
                        var param = new ComponentInstanceParam();
                        param.Name = containerInstance.Name;
                        param.ModuleName = containerInstance.ModuleName;
                        param.ControllerName = containerInstance.ControllerName;
                        param.ComponentID = containerInstance.ComponentID;
                        param.Title = containerInstance.Title;
                        param.ParameterComponent = containerInstance.ParameterComponent;
                        param.PrivateComponent = containerInstance.ParameterComponent;
                        param.RefreshAvailable = containerInstance.RefreshAvailable;
                        param.SettingsAvailable = containerInstance.SettingsAvailable;
                        param.InfoAvailable = containerInstance.InfoAvailable;
                        param.ProjectUrl = containerInstance.ProjectUrl;
                        var coord = containerInstance.GridNode;
                        if (coord != undefined) {
                            param.Col = coord.x;
                            param.Row = coord.y;
                            param.Width = coord.width;
                            param.Height = coord.height;
                        }
                        param.Data = "";
                        var viewInstanceName = $("#" + containerInstance.ComponentID).find(_this.bentasViewTagName).attr("id");
                        if (viewInstanceName)
                            param.Data = JSON.stringify(window[viewInstanceName].filterData());
                        components.push(param);
                    });
                    var formData = new FormData();
                    formData.append("dynamicViewID", viewEntity.DynamicViewID.toString());
                    formData.append("name", viewEntity.Name);
                    formData.append("publicView", viewEntity.PublicView.toString());
                    formData.append("defaultView", viewEntity.DefaultView.toString());
                    formData.append("instances", JSON.stringify(components));
                    this.core.showLoadingSpinner();
                    $.ajax({
                        url: this.combineRootUrl("SaveView"),
                        contentType: false,
                        processData: false,
                        data: formData,
                        method: "POST",
                        success: function (response) {
                            window.location.href = _this.combineRootUrl("Index/" + response.DynamicViewID.toString());
                        }
                    }).always(function () {
                        setTimeout(function () { _this.core.hideLoadingSpinner(); }, 500);
                    });
                };
                DynamicView.prototype.deleteView = function () {
                    var _this = this;
                    if (this.data.ActiveView.PublicView && !this.data.IsRootAdmin) {
                        Dialog_4.Dialog.errorTitle(this.localizer["Hata"], this.localizer["Sistem görünümlerini sadece yönetici silebilir !"]);
                        return;
                    }
                    Dialog_4.Dialog.confirmationTitle(this.localizer["Onay"], kendo.format(this.localizer['{0} isimli görünümü silmek istediğinizden emin misiniz?'], this.data.ActiveView.Name), [this.localizer["Evet"], this.localizer["Hayır"]])
                        .done(function (result) {
                        if (result && result.index === 0) {
                            _this.core.showLoadingSpinner();
                            $.ajax({
                                url: _this.combineRootUrl("DeleteView"),
                                data: { id: _this.data.ActiveView.DynamicViewID },
                                success: function (response) {
                                    window.location.href = _this.combineRootUrl("Index");
                                }
                            }).always(function () {
                                setTimeout(function () { _this.core.hideLoadingSpinner(); }, 500);
                            });
                        }
                    });
                };
                DynamicView.prototype.refreshContainerInstance = function (id, datastr) {
                    var containerInstanceElement = $("#" + id);
                    var viewInstanceElement = $("#" + containerInstanceElement.find(this.bentasViewTagName).attr("id"));
                    var event = new CustomEvent("refeshComponent", { bubbles: true, detail: { datastr: datastr } });
                    viewInstanceElement.length > 0 ? viewInstanceElement.get(0).dispatchEvent(event) : containerInstanceElement.get(0).dispatchEvent(event);
                };
                DynamicView.prototype.disposeViewInstance = function (viewInstanceName) {
                    if (viewInstanceName) {
                        var wnd = window;
                        delete wnd[viewInstanceName];
                        delete wnd.applicationLoader.moduleInstanceItems[viewInstanceName];
                    }
                };
                DynamicView.prototype.refreshAllComponents = function () {
                    var _this = this;
                    this.applyParameterComponentFilterToAllComponents();
                    this.componentInstances.forEach(function (componentInstance) {
                        if (componentInstance.RefreshAvailable) {
                            _this.refreshContainerInstance(componentInstance.ComponentID);
                        }
                    });
                };
                DynamicView.prototype.showComponentList = function () {
                    console.log("showComponentList");
                    Window_1.Window.open(new Window_1.WindowOptions({
                        draggable: true,
                        minimize: true,
                        width: 800,
                        height: 550,
                        modal: false,
                        title: this.localizer["Ekle"],
                        content: $("#componentList")
                    }));
                    $("#componentList").css("display", "block");
                };
                DynamicView.prototype.onSearchChange = function (e, list) {
                    var filter = $(e).val().toString().toLowerCase();
                    $("#" + list + " li").each(function (index, elm) {
                        if (filter === "" || $(elm).text().toLowerCase().indexOf(filter) >= 0)
                            $(elm).css("display", "block");
                        else
                            $(elm).css("display", "none");
                    });
                };
                DynamicView.prototype.applyParameterComponentFilterToAllComponents = function () {
                    var _this = this;
                    var paramters = this.componentInstances.filter(function (i) { return i.ParameterComponent; });
                    if (paramters.length === 1) {
                        var parameterInstance = this.componentInstances.filter(function (comp) { return comp.ParameterComponent; });
                        var parameterViewinstanceName = $("#" + parameterInstance[0].ComponentID).find(this.bentasViewTagName).attr("id");
                        var parameterViewInstance_1 = window[parameterViewinstanceName];
                        this.componentInstances.forEach(function (componentInstance) {
                            var viewInstanceName = $("#" + componentInstance.ComponentID).find(_this.bentasViewTagName).attr("id");
                            if (viewInstanceName) {
                                var viewInstance = window[viewInstanceName];
                                for (var prop in parameterViewInstance_1.data) {
                                    if (prop.substring(0, 1) !== "_" && prop !== "uid") {
                                        if (viewInstance.data.hasOwnProperty(prop)) {
                                            viewInstance.data.set(prop, parameterViewInstance_1.data[prop]);
                                        }
                                    }
                                }
                            }
                        });
                    }
                };
                DynamicView.prototype.crateNewView = function () {
                    window.location.href = this.combineRootUrl("Index/-1");
                };
                DynamicView.prototype.combineRootUrl = function (url) {
                    if (!this.core.parameters.origin.endsWith('/'))
                        return this.core.parameters.origin + "/" + this.data.Url + "/" + url;
                    else
                        return this.core.parameters.origin + this.data.Url + "/" + url;
                };
                DynamicView.prototype.combineOrigin = function (url) {
                    if (!this.core.parameters.origin.endsWith('/'))
                        return this.core.parameters.origin + "/" + url;
                    else
                        return this.core.parameters.origin + url;
                };
                return DynamicView;
            }(ViewBase_1.ViewBase));
            exports_10("DynamicView", DynamicView);
            DynamicViewEntity = (function () {
                function DynamicViewEntity() {
                }
                return DynamicViewEntity;
            }());
            Component = (function () {
                function Component() {
                }
                return Component;
            }());
            ComponentInstance = (function () {
                function ComponentInstance() {
                }
                return ComponentInstance;
            }());
            ComponentInstanceParam = (function () {
                function ComponentInstanceParam() {
                }
                return ComponentInstanceParam;
            }());
            containerHTML = "\n  <div id=\"tabstrip\">\n        <ul>\n        </ul>\n    </div>\n\n<div class=\"new-db-toolbar\">\n\n    <a href=\"#5\" class=\"new-db-toolbar-toggle\">\n        <i class=\"b__icon-settings\"></i>\n    </a>\n\n    <a onclick=\"$page$.crateNewView()\" title=\"Yeni G\u00F6r\u00FCn\u00FCm\" id=\"lcYeniGorunum\">\n        <i class=\"b__icon-insert-invoice\"></i>  Yeni G\u00F6r\u00FCn\u00FCm\n    </a>\n\n\n    <a title=\"Ekle\" id=\"lcEkle\" onclick=\"$page$.showComponentList()\">\n        <i class=\"b__icon-card-add\"></i>Ekle\n    </a>\n\n    <a onclick=\"$page$.showSaveDialog(false)\" title=\"Kaydet\" id=\"lcKaydet\">\n        <i class=\"b__icon-save\"></i>Kaydet\n    </a>\n\n    <a onclick=\"$page$.showSaveDialog(true)\" title=\"Farkl\u0131 Kaydet\" id=\"lcFarkliKaydet\">\n        <i class=\"b__icon-save-as\"></i>Farkl\u0131 Kaydet\n    </a>\n\n    <a onclick=\"$page$.deleteView()\" title=\"G\u00F6r\u00FCn\u00FCm\u00FC Sil\" id=\"lcGorunumuSil\">\n        <i class=\"b__icon-trash\"></i>G\u00F6r\u00FCn\u00FCm\u00FC Sil\n    </a>\n</div>\n\n    <div class=\"b__dashboard-window\" id=\"componentList\" style=\"display:none\">\n        <div class=\"b__container--fluid\">\n            <div class=\"b__form\">\n                <div class=\"b__row\">\n                    <div class=\"b__4 b__sm--4\">\n                        <div class=\"b__row\">\n                            <div class=\"b__12\">\n                                <span id=\"lcParametreler\">Parametreler</span>\n                                <input type=\"text\" tabindex=\"1\" onkeyup=\"$page$.onSearchChange(this,'componentListParametre')\"/>\n                            </div>\n                        </div>\n                        <div class=\"b__row\">\n                            <div class=\"b__12\">\n                                <ul id=\"componentListParametre\">\n                                </ul>\n                            </div>\n                        </div>\n                    </div>\n                    <div class=\"b__4 b__sm--4\">\n                        <div class=\"b__row\">\n                            <div class=\"b__12\">\n                                <span id=\"lcOzel\">\u00D6zel</span>\n                                <input type=\"text\" tabindex=\"2\" onkeyup=\"$page$.onSearchChange(this,'componentListOzel')\"/>\n                            </div>\n                        </div>\n                        <div class=\"b__row\">\n                            <div class=\"b__12\">\n                               <ul id=\"componentListOzel\">\n                               </ul>\n                            </div>\n                        </div>\n                    </div>\n                    <div class=\"b__4 b__sm--4\">\n                        <div class=\"b__row\">\n                            <div class=\"b__12\">\n                                <span id=\"lcGenel\">Genel</span>\n                                <input type=\"text\" tabindex=\"3\" onkeyup=\"$page$.onSearchChange(this,'componentListGenel')\"/>\n                            </div>\n                        </div>\n                        <div class=\"b__row\">\n                            <div class=\"b__12\">\n                                <ul id=\"componentListGenel\">\n                                </ul>\n                            </div>\n                        </div>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n\n    <section class=\"b__dashboard--section\">\n        <div class=\"grid-stack\">\n\n        </div>\n    </section>\n\n    <script type=\"text/x-kendo-template\" id=\"component-template\">\n        <div class=\"grid-stack-item b__dashboard--grid-panel\" id=\"#:data.ComponentID#\">\n            <div class=\"grid-stack-item-content #:data.CssClasses#\">\n                <div class=\"grid-stack-item-header b__dashboard--panel--header b__dashboard--panel--header--hover\">\n                    <div class=\"b__dashboard--panel--header-left\">\n                        <a class=\"b__dashboard--info-button #:data.InfoAvailable?'componentInfoButton':''#\" #:data.InfoAvailable?'':'disabled'# role=\"button\"><i class=\"b__icon-help-circle-outline b__float--right\"></i></a>\n                        <div class=\"b__dashboard--panel--title\">#: data.Title #</div>\n                    </div>\n                    <div class=\"b__dashboard--panel--header-right\">\n                        <a class=\"b__dashboard--remove-button\" role=\"button\" onclick=\"$page$.removeComponentInstance('#: data.ComponentID #')\"><i class=\"b__icon-circle-cancel b__float--right\"></i></a>\n                        <a class=\"b__dashboard--settings-button\" role=\"button\" onclick=\"$page$.callComponentInstanceSettings('#: data.ComponentID #')\"><i class=\"b__icon-settings-2 b__float--right\"></i></a>\n                        <a class=\"b__dashboard--refresh-button\" role=\"button\" onclick=\"$page$.refreshContainerInstance('#: data.ComponentID #')\"><i class=\"b__icon-refresh b__float--right\"></i></a>\n                    </div>\n                </div>\n                <div class=\"b__dashboard--panel--content\">\n                </div>\n            </div>\n        </div>\n    </script>\n\n    <script type=\"text/x-kendo-template\" id=\"component-list-item-template\">\n        <li><a href=\"javascript:void(0)\" onclick=\"$page$.createEmptyContainerInstance('#: data.ModuleName #','#: data.ControllerName #', '#: data.Name #')\"><i class=\"b__icon-layers\"></i>#: data.Title #</a></li>\n    </script>\n\n    <script type=\"text/x-kendo-template\" id=\"save-dialog-template\">\n            <div id=\"saveDialog\">\n            <div>\n                <label for=\"saveDialogName\">lcAciklama</label><input type=\"text\" id=\"saveDialogName\" name=\"saveDialogName\">\n            </div>\n\n            <div class=\"b__my--3\">\n                <input id=\"saveDialogDefaultView\" class=\"k-checkbox\" type=\"checkbox\" name=\"saveDialogDefaultView\">\n                <label for=\"saveDialogDefaultView\" class=\"k-checkbox-label b__mr--3\">lcVarsayilanGorunum</label>\n            </div>\n            <div class=\"b__mb--2\">\n                <input id=\"saveDialogPublicView\" class=\"k-checkbox\" type=\"checkbox\" name=\"saveDialogPublicView\">\n                <label for=\"saveDialogPublicView\" class=\"k-checkbox-label b__mr--3\" id=\"saveDialogPublicViewLabel\">lcGenelGorunum</label>\n            </div>\n        </div>\n    </script>\n\n     <script type=\"text/x-kendo-template\" id=\"view-menuitem-template\">\n            #if(data.publicView){#\n                <li for=\"#: data.caption #\">\n                    \n                    <a href=\"#: data.url #\"><i class=\"b__icon-user\"></i> #: data.caption #</a>\n                </li>\n            #}else{#\n                 <li for=\"#: data.caption #\">\n                    <a href=\"#: data.url #\"><i class=\"b__icon-settings-2\"></i> #: data.caption #</a>\n                </li>\n            #}#     \n    </script>\n";
        }
    };
});
System.register("DynamicViewComponent", ["ViewBase", "Dialog", "DynamicView"], function (exports_11, context_11) {
    "use strict";
    var ViewBase_2, Dialog_5, DynamicView_1, DynamicViewComponent;
    var __moduleName = context_11 && context_11.id;
    return {
        setters: [
            function (ViewBase_2_1) {
                ViewBase_2 = ViewBase_2_1;
            },
            function (Dialog_5_1) {
                Dialog_5 = Dialog_5_1;
            },
            function (DynamicView_1_1) {
                DynamicView_1 = DynamicView_1_1;
            }
        ],
        execute: function () {
            DynamicViewComponent = (function (_super) {
                __extends(DynamicViewComponent, _super);
                function DynamicViewComponent() {
                    var _this = _super.call(this) || this;
                    _this.dynamicView = function () {
                        var moduleItems = window["applicationLoader"]["moduleInstanceItems"];
                        for (var m in moduleItems) {
                            if (moduleItems[m].instance instanceof DynamicView_1.DynamicView) {
                                return moduleItems[m].instance;
                            }
                        }
                    };
                    return _this;
                }
                DynamicViewComponent.prototype.bind = function () {
                    this.core.bind(this.settingsSelector(), this.data);
                };
                DynamicViewComponent.prototype.documentReady = function () {
                    $("#" + this.instanceName).get(0).addEventListener("refeshComponent", this.refreshEventHandler);
                    $('.grid-stack').trigger('gsresizestop');
                };
                DynamicViewComponent.prototype.refresh = function () {
                    $("#" + this.instanceName).get(0).dispatchEvent(new CustomEvent("refeshComponent", { bubbles: true, detail: {} }));
                };
                DynamicViewComponent.prototype.refreshEventHandler = function (e) {
                };
                DynamicViewComponent.prototype.settingsSelector = function () {
                    return "#" + this.instanceName + "_settings";
                };
                DynamicViewComponent.prototype.settings = function (containerInstanceElement) {
                    var settingsContainerElement = containerInstanceElement.find(this.settingsSelector());
                    var parentElement = settingsContainerElement.parent();
                    return Dialog_5.Dialog.confirmation(new Dialog_5.DialogOptions({
                        content: "",
                        open: function (e) {
                            settingsContainerElement.removeAttr("style").appendTo(e.sender.wrapper.find(".k-dialog-content"));
                        },
                        buttons: [
                            new Dialog_5.DialogButton({
                                text: "Tamam",
                                onclick: function (e, btn, dlg) {
                                    dlg.close();
                                }
                            })
                        ]
                    })).always(function () {
                        settingsContainerElement.attr("style", "display:none;").appendTo(parentElement);
                    });
                };
                DynamicViewComponent.prototype.filterData = function () {
                    return this.data ? this.data._toJSON() : this.data;
                };
                DynamicViewComponent.prototype.findElement = function (id) {
                    if (id.indexOf("#") === 0)
                        id = id.substring(1);
                    return $("#" + this.instanceName + "_" + id);
                };
                DynamicViewComponent.prototype.getGrid = function (id) {
                    return this.findElement(id).data("kendoGrid");
                };
                return DynamicViewComponent;
            }(ViewBase_2.ViewBase));
            exports_11("DynamicViewComponent", DynamicViewComponent);
        }
    };
});
System.register("Bentas", ["Core", "Dialog", "Mobile", "Observable", "Print", "Window", "Menu", "ViewBase", "DynamicViewComponent", "DynamicView", "FindDialog"], function (exports_12, context_12) {
    "use strict";
    var Core_4, Dialog_6, Mobile_2, Observable_2, Print_1, Window_2, Menu_2, ViewBase_3, DynamicViewComponent_1, DynamicView_2, FindDialog_2;
    var __moduleName = context_12 && context_12.id;
    return {
        setters: [
            function (Core_4_1) {
                Core_4 = Core_4_1;
            },
            function (Dialog_6_1) {
                Dialog_6 = Dialog_6_1;
            },
            function (Mobile_2_1) {
                Mobile_2 = Mobile_2_1;
            },
            function (Observable_2_1) {
                Observable_2 = Observable_2_1;
            },
            function (Print_1_1) {
                Print_1 = Print_1_1;
            },
            function (Window_2_1) {
                Window_2 = Window_2_1;
            },
            function (Menu_2_1) {
                Menu_2 = Menu_2_1;
            },
            function (ViewBase_3_1) {
                ViewBase_3 = ViewBase_3_1;
            },
            function (DynamicViewComponent_1_1) {
                DynamicViewComponent_1 = DynamicViewComponent_1_1;
            },
            function (DynamicView_2_1) {
                DynamicView_2 = DynamicView_2_1;
            },
            function (FindDialog_2_1) {
                FindDialog_2 = FindDialog_2_1;
            }
        ],
        execute: function () {
            exports_12("Core", Core_4.Core);
            exports_12("CoreOptions", Core_4.CoreOptions);
            exports_12("Dialog", Dialog_6.Dialog);
            exports_12("DialogButton", Dialog_6.DialogButton);
            exports_12("DialogOptions", Dialog_6.DialogOptions);
            exports_12("Mobile", Mobile_2.Mobile);
            exports_12("Observable", Observable_2.Observable);
            exports_12("Print", Print_1.Print);
            exports_12("PrintOptions", Print_1.PrintOptions);
            exports_12("PrintMode", Print_1.PrintMode);
            exports_12("Window", Window_2.Window);
            exports_12("WindowOptions", Window_2.WindowOptions);
            exports_12("Menu", Menu_2.Menu);
            exports_12("ViewBase", ViewBase_3.ViewBase);
            exports_12("DynamicViewComponent", DynamicViewComponent_1.DynamicViewComponent);
            exports_12("DynamicView", DynamicView_2.DynamicView);
            exports_12("FindDialog", FindDialog_2.FindDialog);
        }
    };
});
