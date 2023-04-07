
export enum AuthMethod {
  Default,
  Google
}

export interface AuthRequestModel {
  token : string;
  method : AuthMethod
}
