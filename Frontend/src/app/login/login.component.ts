import { Component, inject, resolveForwardRef } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loggedIn = false;
  private accountService = inject(AccountService);
  body:any = {};

  login(){
    this.accountService.login(this.body).subscribe({
      next: response => {
        console.log(response);
        this.loggedIn = true;
      },
        error: error => console.log(error)
    })
  }
}
