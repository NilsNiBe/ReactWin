import { Bridge } from "./bridgeManager";

export interface CallbackBridge extends Bridge {
  setText(text: string): void;
}
