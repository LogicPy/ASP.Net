import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';

@Component({
 selector: 'app-root',
 templateUrl: './app.component.html',
 styleUrls: ['./app.component.css']
})
export class AppComponent {
 title = 'login-form';
 //user input
 userName: string;
 password: string;

 //constructor
 constructor(private http: HttpClient, private router: Router) {
 }

 //function to login
 login() {
   let userData = {
     username: this.userName,
     password: this.password
   };
   //API call to server
   this.http.post('http://localhost:50000/api/login', userData).subscribe(data => {
     if (data) {
       //if login successful, navigate to dashboard
       this.router.navigate(['/dashboard']);
     } else {
       //if login fails, display error message
       alert("Invalid username or password");
     }
   });
 }
}