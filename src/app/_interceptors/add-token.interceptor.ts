import { HttpInterceptorFn } from '@angular/common/http';
export const addTokenInterceptor: HttpInterceptorFn = (req, next) => {
  let token = localStorage.getItem("token")
  if (token != null){
    req = req.clone({setHeaders:{
      'Authorization':`bearer ${token}`
    }})
    console.log(req);
    
  }
  return next(req);
};
