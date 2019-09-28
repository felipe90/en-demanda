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
      {label: "Trabajos", link: "", icon: "assignment"},
      {label: "Habilidades", link: "", icon: "assignment"},
      {label: "Campos de accion", link: "", icon: "assignment"},
      {label: "Recursos", link: "", icon: "assignment"},
      {label: "Educacion", link: "", icon: "assignment"},
      {label: "Perfil", link: "", icon: "assignment"},
    ]

  }

}
