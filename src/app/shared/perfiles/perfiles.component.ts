import { Component, OnInit } from '@angular/core';
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
        desc: "",
        img: "",
        skills: [
          { name: "Habilidad", level: 0 },
          { name: "Habilidad", level: 0 },
        ]
      },
      {
        name: "John Ramirez",
        desc: "",
        img: "",
        skills: [
          { name: "Habilidad", level: 0 },
          { name: "Habilidad", level: 0 },
          { name: "Habilidad", level: 0 },
          { name: "Habilidad", level: 0 }
        ]
      },
      {
        name: "John Ramirez",
        desc: "",
        img: "",
        skills: [
          { name: "Habilidad", level: 0 },
          { name: "Habilidad", level: 0 },
          { name: "Habilidad", level: 0 },
        ]
      },
      {
        name: "John Ramirez",
        desc: "",
        img: "",
        skills: [
          { name: "Habilidad", level: 0 },
          { name: "Habilidad", level: 0 },
          { name: "Habilidad", level: 0 },
        ]
      },
      {
        name: "John Ramirez",
        desc: "",
        img: "",
        skills: [
          { name: "Habilidad", level: 0 },
          { name: "Habilidad", level: 0 },
        ]
      },
      {
        name: "John Ramirez",
        desc: "",
        img: "",
        skills: [
          { name: "Habilidad", level: 0 },
          { name: "Habilidad", level: 0 },
        ]
      }
    ]

    this.profiles.forEach(item => {
      item.desc = "lorem ";
      item.img = './assets/John.jpg';
      item.skills.forEach(skill => {
        skill.level = Math.floor(Math.random() * 10);
      });
    });
  }

}
