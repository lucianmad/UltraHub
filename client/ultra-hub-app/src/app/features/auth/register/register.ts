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
  username = '';
  email = '';
  password = '';
  confirmPassword = '';

  private http = inject(HttpClient);

  register(){
    this.http.post('api/auth/register', {username: this.username, email: this.email, password: this.password, confirmPassword: this.confirmPassword})
    .subscribe({
      next: (response : any) => {
        console.log("Succesfully registered!", response.token);
      },
      error: error => {
        console.log("Register failed", error)
      }
    })
  }
}
