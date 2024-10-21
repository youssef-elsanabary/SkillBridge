import { CanActivateFn, Router } from '@angular/router';
import { AccountService } from '../_services/account.service';
import { inject } from '@angular/core';

export const canLoginGuard: CanActivateFn = (route, state) => {
  let accountService : AccountService = inject(AccountService)
    if(accountService.isAuth) return true;
    let router : Router = inject(Router)
    router.navigateByUrl("account/login")
    return false
};
