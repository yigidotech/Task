import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from "@angular/router";
import { Injectable } from "@angular/core";
import { UserService } from "./user.service";

@Injectable()
export class LoginGuard implements CanActivate {
    constructor(private userservice: UserService, private router: Router) { }

    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): boolean {
        let logged = this.userservice.isLoggedIn();
        if (logged) {
            return true;
        } else {
            this.router.navigate(["login"]);
        }
        return false;
    }
}