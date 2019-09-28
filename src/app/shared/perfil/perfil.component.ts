import { Component, Input, OnInit } from '@angular/core';
import { Profile } from '../profile.model';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css']
})
export class PerfilComponent implements OnInit {

  @Input('profile') profile: Profile = null;

  constructor() { }

  ngOnInit() {

  }

}
