import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Base } from '../_modules/base';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  
  constructor(public http:HttpClient, public base : Base) { }
}
