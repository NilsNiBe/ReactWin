
export class Bridge {
  private triggerEvent(eventName: string, args: any) {
    const listeners = this.getEventListeners(eventName);

    listeners.forEach(listener => {
      listener(args);
    });
  }

  private _eventListeners : {[key: string]: any} = {};

  getEventListeners(eventName: string): any[] {
    if (this._eventListeners[eventName] === undefined) {
      return [];
    } else {
      return this._eventListeners[eventName];
    }
  }

  addEventListener(eventName: string, delegate: any) {
    if (this._eventListeners[eventName] === undefined) {
      this._eventListeners[eventName] = [delegate];
    } else {
      this._eventListeners[eventName].push(delegate);
    }
  }
}
