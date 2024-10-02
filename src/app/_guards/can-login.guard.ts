import { CanActivateFn } from '@angular/router';

export const canLoginGuard: CanActivateFn = (route, state) => {
  return true;
};
