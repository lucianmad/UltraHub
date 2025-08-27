import {Component, inject} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {FormsModule} from '@angular/forms';

@Component({
  selector: 'app-register',
  imports: [
    FormsModule
  ],
  templateUrl: './register.html',
  styleUrl: './register.scss'
})
export class Register {
  userObj : any = {
    "username": '',
    "email": '',
    "password": '',
    "confirmPassword": '',
  };

  private http = inject(HttpClient);

  register(){
    this.http.post('api/auth/register', this.userObj)
    .subscribe({
      next: (response : any) => {
        console.log("Successfully registered!", response.token);
      },
      error: (error: any) => {
        console.log("Register failed", error)
      }
    })
  }
}
