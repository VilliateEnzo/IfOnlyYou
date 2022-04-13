import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MemberDetailComponent } from './member-detail/member-detail.component';
import { MemberListComponent } from './member-list/member-list.component';
import { MembersRoutingModule } from './members-routing.module';
import { MemberCardComponent } from './member-card/member-card.component';
import { SharedModule } from '../shared/shared.module';
import { MemberGalleryComponent } from './member-gallery/member-gallery.component';



@NgModule({
  declarations: [
    MemberDetailComponent,
    MemberListComponent,
    MemberCardComponent,
    MemberGalleryComponent
  ],
  imports: [
    CommonModule,
    MembersRoutingModule,
    SharedModule
  ]
})
export class MembersModule { }
