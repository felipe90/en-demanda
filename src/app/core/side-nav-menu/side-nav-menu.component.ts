import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-side-nav-menu',
  templateUrl: './side-nav-menu.component.html',
  styleUrls: ['./side-nav-menu.component.css']
})
export class SideNavMenuComponent implements OnInit {

  public menuItems: { label: string, link: string, icon: string}[] =  []

  constructor() { }

  ngOnInit() {

    this.menuItems = [
      {label: "Trabajos", link: "", icon: "keyboard_arrow_right"},
      {label: "Habilidades", link: "", icon: "keyboard_arrow_right"},
      {label: "Campos de accion", link: "", icon: "keyboard_arrow_right"},
      {label: "Recursos", link: "", icon: "keyboard_arrow_right"},
      {label: "Educacion", link: "", icon: "keyboard_arrow_right"},
      {label: "Perfil", link: "", icon: "keyboard_arrow_right"},
    ]

  }

}
