/// <reference path="../../../Typescript/@types/jquery/index.d.ts" />
/// <reference path="../../../Typescript/@types/mcustomscrollbar/index.d.ts" />
/// <reference path="../../../Typescript/@types/kendo-ui/index.d.ts" />
/// <reference path="../../../Typescript/@types/SignalR/index.d.ts" />
/// <reference types="jquery" />
/// <reference types="mcustomscrollbar" />
/// <reference types="kendo-ui" />
declare module "Menu" {
    export class Menu {
        private menuModalBackground;
        initMenu(): void;
        menuModalOpen(): void;
        menuModalClose(): void;
        menuStickyRelocate(): void;
    }
}
declare module "Dialog" {
    export class DialogButton {
        constructor(init?: Partial<DialogButton>);
        text: string;
        primary: boolean;
        default: boolean;
        clicked: boolean;
        onclick: any;
        dialogid: string;
        onClickProxy: (e: any) => boolean;
    }
    export class DialogOptions {
        constructor(init?: Partial<DialogOptions>);
        title: string;
        content: string | JQuery<HTMLElement>;
        titleClass: string;
        height?: number | string;
        width?: number | string;
        buttonLayout: string;
        buttons: Array<DialogButton | string>;
        closable: boolean;
        open: any;
        close: any;
        extraOptions: any;
    }
    export class Dialog {
        private constructor();
        private static showDialog;
        private static checkButtons;
        static information(param: DialogOptions): JQuery.Deferred<any, any, any>;
        static information(content: string | JQuery<HTMLElement>, width?: number | string, height?: number | string): JQuery.Deferred<any, any, any>;
        static informationTitle(title: string, content: string | JQuery<HTMLElement>, width?: number | string, height?: number | string): JQuery.Deferred<any, any, any>;
        static error(param: DialogOptions): JQuery.Deferred<any, any, any>;
        static error(content: string | JQuery<HTMLElement>, width?: number | string, height?: number | string): JQuery.Deferred<any, any, any>;
        static errorTitle(title: string, content: string | JQuery<HTMLElement>, width?: number | string, height?: number | string): JQuery.Deferred<any, any, any>;
        static confirmation(param: DialogOptions): JQuery.Deferred<any, any, any>;
        static confirmation(content: string | JQuery<HTMLElement>, buttons: Array<DialogButton | string>, width?: number | string, height?: number | string): JQuery.Deferred<any, any, any>;
        static confirmationTitle(title: string, content: string | JQuery<HTMLElement>, buttons: Array<DialogButton | string>, width?: number | string, height?: number | string): JQuery.Deferred<any, any, any>;
        static warning(param: DialogOptions): JQuery.Deferred<any, any, any>;
        static warning(content: string | JQuery<HTMLElement>, width?: number | string, height?: number | string): JQuery.Deferred<any, any, any>;
        static warningTitle(title: string, content: string | JQuery<HTMLElement>, width?: number | string, height?: number | string): JQuery.Deferred<any, any, any>;
        static custom(param: DialogOptions): JQuery.Deferred<any, any, any>;
        static custom(content: string | JQuery<HTMLElement>, buttons?: Array<DialogButton | string>, width?: number | string, height?: number | string): JQuery.Deferred<any, any, any>;
        static customTitle(title: string, content: string | JQuery<HTMLElement>, buttons?: Array<DialogButton | string>, width?: number | string, height?: number | string): JQuery.Deferred<any, any, any>;
    }
}
declare module "Observable" {
    export class Observable {
        private core;
        constructor();
        private _bindDataSourceEvents;
        private _internal_ObservableToJSON;
        private _internal_observableToJSONStringify;
        observable: (object: any) => kendo.data.ObservableObject;
    }
}
declare module "Core" {
    import { ViewBase } from "Bentas";
    export class CoreOptions {
        internalDebugInfo: boolean;
        createObservableEmptyEvents: boolean;
    }
    export class Core {
        private signaleRListeners;
        private static instance;
        static getInstance(): Core;
        private parameterList;
        constructor();
        registerSignalRListener(listener: Function | ViewBase): void;
        unRegisterSignalRListener(listener: Function | ViewBase): void;
        dispatchSignalRMessage(message: any): void;
        private _globalDocumentReady;
        options: CoreOptions;
        bind(element: string, viewModel: any): void;
        printDebugInfo(...args: any[]): void;
        validator(e: any): void;
        replaceAll(s: string, search: string, replace: string): string;
        formatString(str: string, ...val: any[]): string;
        private onKeyDownDropDownListFilter;
        private onClickDropDownListFilter;
        refreshAllDropDownTexts(): void;
        refreshDropDownText(element: JQuery<HTMLElement>): void;
        onCloseDropDownList: (e: kendo.ui.DropDownListCloseEvent) => void;
        onPopUpDropDownList: (e: kendo.ui.DropDownListOpenEvent) => void;
        hideColHeaders(id: string): void;
        hideAllColumnMenus(): void;
        toStringWN(o: any, f: string): string;
        lookupFormat(o: any): any;
        lookupFormat2(id: string, field: string, textField: string, source: any): any;
        validateDateInput(selector: string): void;
        dateInputOnClick(selector: string): void;
        setOnFocusForSelectAll(selector: string): void;
        gridFilterToolbarRefreshToggleStates(toolbarId: string, data: any): void;
        gridFilterToolbarOnToggle(gridId: string, data: any, e: kendo.ui.ToolBarToggleEvent): void;
        gridOnError(e: any): void;
        getRowTemplate(templateId: string, gridId: string, hasDetail?: boolean): (data: any) => string;
        showLoadingSpinner(text?: any): void;
        hideLoadingSpinner(): void;
        openSlider(selector: string): void;
        closeSlider(selector: string): void;
        clearFilterObject(object: any, pristine: any): void;
        get parameters(): any;
        createErrorString(errorJson: any): string;
        closeAllWindow(): void;
        addAntiForgeryTokens(param: any): any;
        combobox2OnChange(): void;
        dtpOnChange(): void;
        datePickerCheckValueOnFocusOut(): void;
        dateTimePickerCheckValueOnFocusOut(): void;
        isNullOrEmpty(value: any): boolean;
    }
}
declare module "Mobile" {
    export class Mobile {
        private constructor();
        static Android(): boolean;
        static BlackBerry(): boolean;
        static iOS(): boolean;
        static Opera(): boolean;
        static Windows(): boolean;
        static Any(): boolean;
    }
}
declare module "Print" {
    export enum PrintMode {
        popup = 0,
        iframe = 1
    }
    export class PrintOptions {
        constructor(printMode?: PrintMode, footer?: string);
        printMode: PrintMode;
        footer: string;
    }
    export class Print {
        private constructor();
        static printElement(selector: string, options?: PrintOptions): void;
        static printElement(selector: string, printMode?: PrintMode): void;
        private static prepareHtml;
        private static printHtmlPopUp;
        private static printHtmlIFrame;
        private static callPrint;
    }
}
declare module "Window" {
    export class ActiveWindow {
        window: kendo.ui.Window;
        data: any;
        constructor(window: kendo.ui.Window);
    }
    export class WindowOptions {
        constructor(init?: Partial<WindowOptions>);
        title: string;
        modal: boolean;
        draggable: boolean;
        content: string | JQuery<HTMLElement>;
        visible: boolean;
        animation: boolean;
        minimize: boolean;
        open?(e: kendo.ui.WindowEvent): void;
        close?(e: kendo.ui.WindowCloseEvent): void;
        width?: number | string;
        height?: number | string;
    }
    export class Window {
        static activeWindow: ActiveWindow;
        private constructor();
        static open(param: WindowOptions): JQuery.Deferred<any, any, any>;
        static open(title: string, content: string | JQuery<HTMLElement>, modal?: boolean): JQuery.Deferred<any, any, any>;
    }
}
declare module "FindDialog" {
    export class FindDialog {
        static open(params: any): JQuery.Deferred<any>;
        private static clearFilter;
        private static setFilter;
    }
}
declare module "ViewBase" {
    import { Core } from "Core";
    export class ViewBase<T = any> {
        protected __this: this;
        core: Core;
        data: T;
        localizer: any;
        instanceName: string;
        constructor();
        signalRListener(messsage: any): void;
        observable(data: any): kendo.data.ObservableObject;
        documentReady(): void;
        bind(): void;
        findElement(id: string): JQuery<HTMLElement>;
        getDropDownList(id: string): kendo.ui.DropDownList;
        getDropDownListDataSource(id: string): kendo.data.DataSource;
        getGrid(id: string): kendo.ui.Grid;
        replaceInstanceName(content: string, isCompoentModule?: boolean): string;
        findDialog(dialogId: string, fieldMaps?: Array<string> | string): JQuery.Deferred<any>;
    }
}
declare module "DynamicView" {
    import { ViewBase } from "ViewBase";
    export class DynamicView extends ViewBase {
        private gridstack;
        components: Component[];
        componentInstances: ComponentInstance[];
        private componentTemplate;
        private componentListItemTemplate;
        private bentasViewTagName;
        private tooltip;
        constructor();
        bind(): void;
        documentReady(): void;
        prepareViewsMenu(): void;
        prepareHover(): void;
        getComponentList(): void;
        getView(): void;
        showSaveDialog(saveAs: boolean): void;
        saveView(viewEntity: DynamicViewEntity): void;
        deleteView(): void;
        createEmptyContainerInstance: (moduleName: string, controllerName: string, componentName: string) => void;
        createContainerInstance: (param: ComponentInstanceParam) => void;
        refreshComponentEventHandler: (e: any) => void;
        refreshContainerInstance(id: string, datastr?: string): void;
        callComponentInstanceSettings: (id: string) => void;
        removeComponentInstance: (id: string) => void;
        private disposeViewInstance;
        refreshAllComponents(): void;
        showComponentList(): void;
        onSearchChange(e: any, list: string): void;
        applyParameterComponentFilterToAllComponents(): void;
        crateNewView(): void;
        combineRootUrl(url: string): string;
        combineOrigin(url: string): string;
    }
    class DynamicViewEntity {
        DynamicViewID: number;
        Name: string;
        PublicView: boolean;
        DefaultView: boolean;
    }
    class Component {
        ProjectUrl: string;
        ModuleName: string;
        ControllerName: string;
        Name: string;
        ParameterComponent: boolean;
        PrivateComponent: boolean;
        SettingsAvailable: boolean;
        RefreshAvailable: boolean;
        InfoAvailable: boolean;
        Title: string;
        Width: number;
        Height: number;
        Method: string;
        CssClasses: string;
    }
    class ComponentInstance {
        ComponentID: string;
        Title: string;
        ProjectUrl: string;
        ModuleName: string;
        ControllerName: string;
        Name: string;
        ParameterComponent: boolean;
        PrivateComponent: boolean;
        SettingsAvailable: boolean;
        RefreshAvailable: boolean;
        InfoAvailable: boolean;
        GridNode: any;
        CssClasses: string;
    }
    class ComponentInstanceParam {
        ComponentID: string;
        Title: string;
        ProjectUrl: string;
        ModuleName: string;
        ControllerName: string;
        Name: string;
        ParameterComponent: boolean;
        PrivateComponent: boolean;
        SettingsAvailable: boolean;
        RefreshAvailable: boolean;
        InfoAvailable: boolean;
        Col: number;
        Row: number;
        Width: number;
        Height: number;
        Data: string;
    }
}
declare module "DynamicViewComponent" {
    import { ViewBase } from "ViewBase";
    export class DynamicViewComponent extends ViewBase {
        containerInstance: any;
        containerId: any;
        constructor();
        dynamicView: any;
        bind(): void;
        documentReady(): void;
        refresh(): void;
        protected refreshEventHandler(e: CustomEvent): void;
        protected settingsSelector(): string;
        settings(containerInstanceElement: JQuery<HTMLElement>): any;
        filterData(): any;
        findElement(id: string): JQuery<HTMLElement>;
        getGrid(id: string): kendo.ui.Grid;
    }
}
declare module "Bentas" {
    import { Core, CoreOptions } from "Core";
    import { Dialog, DialogButton, DialogOptions } from "Dialog";
    import { Mobile } from "Mobile";
    import { Observable } from "Observable";
    import { Print, PrintOptions, PrintMode } from "Print";
    import { Window, WindowOptions } from "Window";
    import { Menu } from "Menu";
    import { ViewBase } from "ViewBase";
    import { DynamicViewComponent } from "DynamicViewComponent";
    import { DynamicView } from "DynamicView";
    import { FindDialog } from "FindDialog";
    export { Core, CoreOptions, Window, WindowOptions, Dialog, DialogButton, DialogOptions, Mobile, Observable, Print, PrintOptions, PrintMode, ViewBase, Menu, DynamicViewComponent, DynamicView, FindDialog };
}
