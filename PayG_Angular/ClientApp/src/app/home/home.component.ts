import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  constructor(private http: HttpClient, @Inject('BASE_URL') private x: string) { }


  ngOnInit() {

    //this.http.get<string>(this.x + "home/fetchdata").subscribe((d) => { console.log(d); });
    }
}
