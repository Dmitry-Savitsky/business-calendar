import { makeAutoObservable } from 'mobx';

export default class UserStore {

  constructor() {
    this._isAuth = localStorage.getItem('isAuth') === 'true';
    this._user = null;
    makeAutoObservable(this);
  }
  

  setIsAuth(bool) {
    this._isAuth = bool;
    localStorage.setItem('isAuth', bool ? 'true' : 'false');
  }


  setUser(user) {
    this._user = user;
  }

  get isAuth() {
    return this._isAuth;
  }

  get user() {
    return this._user;
  }
}