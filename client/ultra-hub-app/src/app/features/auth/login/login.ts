import {Component, inject} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-login',
  imports: [
    FormsModule,
  ],
  templateUrl: './login.html',
  styleUrl: './login.scss'
})
export class Login {
  userObj : any = {
    "email": '',
    "password": '',
  }

  private http = inject(HttpClient);

  login(){
    this.http.post('/api/auth/login', this.userObj)
      .subscribe({
        next: (response: any) => {
          console.log('Successfully logged in! Token: ', response.token);
        },
        error: (error: any) => {
          console.log('Login failed!', error);
        }
      });
  }
}
