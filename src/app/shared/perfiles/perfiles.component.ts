import { Component, OnInit } from '@angular/core';
import { importExpr } from '@angular/compiler/src/output/output_ast';
import { Profile } from '../profile.model';

@Component({
  selector: 'app-perfiles',
  templateUrl: './perfiles.component.html',
  styleUrls: ['./perfiles.component.css']
})
export class PerfilesComponent implements OnInit {

  public profiles: Profile[] = [];
  public panelOpenState = false;

  constructor() { }

  ngOnInit() {

    this.profiles = [
      {
        name: "John Ramirez",
        age: 20,
        desc: "",
        img: "",
        skills: [
          { name: "Carpinteria", level: 0 },
          { name: "Jardineria", level: 0 },
        ]
      },
      {
        name: "John Ramirez",
        age: 20,
        desc: "",
        img: "",
        skills: [
          { name: "Lectura", level: 0 },
          { name: "Jardineria", level: 0 },
        ]
      },
      {
        name: "John Ramirez",
        desc: "",
        age: 20,
        img: "",
        skills: [
          { name: "Limpieza", level: 0 },
          { name: "Carpinteria", level: 0 },
          { name: "Construccion", level: 0 },
        ]
      },
      {
        name: "John Ramirez",
        desc: "",
        age: 20,
        img: "",
        skills: [
          { name: "Construccion", level: 0 },
          { name: "Carpinteria", level: 0 },
        ]
      },
      {
        name: "John Ramirez",
        desc: "",
        age: 20,
        img: "",
        skills: [
          { name: "Habilidad", level: 0 },
          { name: "Jardineria", level: 0 },
        ]
      },
      {
        name: "John Ramirez",
        desc: "",
        age: 20,
        img: "",
        skills: [
          { name: "Carpinteria", level: 0 },
          { name: "Limpieza", level: 0 },
        ]
      }
    ]

    this.profiles.forEach(item => {
      item.desc = "lorem ";
      item.img = './assets/John.jpg';
      item.desc = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse venenatis mauris ut nisi vulputate faucibus.  "
      item.skills.forEach(skill => {
        skill.level = Math.floor(Math.random() * 10);
      });
    });
  }

}
