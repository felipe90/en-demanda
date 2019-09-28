import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { SideNavComponent } from './side-nav/side-nav.component';
import { SideNavMenuComponent } from './side-nav-menu/side-nav-menu.component';

@NgModule({
    imports: [
        CommonModule,
        SharedModule,
    ],
    exports: [
        HeaderComponent,
        SideNavComponent,
        SideNavMenuComponent
    ],
    declarations: [
        HeaderComponent,
        SideNavComponent,
        SideNavMenuComponent
    ]
})
export class CoreModule { }