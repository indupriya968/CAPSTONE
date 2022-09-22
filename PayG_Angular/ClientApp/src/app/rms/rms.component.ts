import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IUser } from '../IUser';

@Component({
  selector: 'app-rms',
  templateUrl: './rms.component.html',
  styleUrls: ['./rms.component.css']
})
export class RMSComponent implements OnInit {
 

  regForm: any;
  public user: IUser = { FIRSTNAME: '', LASTNAME: '', USERNAME: '', PASSWORD: '' };

  public status: boolean = false;
    mapFormValuesToModel: any;

  constructor(private fb: FormBuilder, private http: HttpClient, private router: Router,
@Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit(): void {
    this.regForm = this.fb.group({
      FIRSTNAME: (['', Validators.required]),
      LASTNAME: (['', Validators.required]),
      USERNAME: (['', Validators.required]),
      PASSWORD: (['', Validators.required]),
      appcode:"johnydeph"

    });
  }
  mapvaluestoobject() {
    this.user = {
      FIRSTNAME: this.regForm.get('FIRSTNAME').value,
      LASTNAME: this.regForm.get('LASTNAME').value,
      USERNAME: this.regForm.get('USERNAME').value,
      PASSWORD: this.regForm.get('PASSWORD').value
    }
  }
  registerClick(): void {

    if (this.regForm.valid) {
      this.mapvaluestoobject();
     
      console.log(this.user);
     
      this.http.post<boolean>(this.baseUrl + 'home/register', this.user).subscribe((r) => { this.status = r; console.log(r); });
    }

  }
}
