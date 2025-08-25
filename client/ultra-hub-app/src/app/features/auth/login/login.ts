import {Component, inject} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    FormsModule,
  ],
  templateUrl: './login.html',
  styleUrl: './login.scss'
})
export class Login {
  email = '';
  password = '';

  private http = inject(HttpClient);

  login(){
    this.http.post('/api/auth/login', {email: this.email, password: this.password})
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
