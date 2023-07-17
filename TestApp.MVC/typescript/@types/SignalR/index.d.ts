// Type definitions for SignalR
// Murat MERT (þimdilik lazým olan kadarýný yazdým)


/// <reference types="jquery" />


declare namespace signalR {
    class HubConnectionBuilder {
        public withUrl(url: string): any;
    }
}

