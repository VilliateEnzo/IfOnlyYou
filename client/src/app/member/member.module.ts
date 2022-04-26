import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MemberDetailComponent } from './member-detail/member-detail.component';
import { MemberListComponent } from './member-list/member-list.component';
import { MemberRoutingModule } from './member-routing.module';
import { MemberCardComponent } from './member-card/member-card.component';
import { SharedModule } from '../shared/shared.module';
import { MemberGalleryComponent } from './member-gallery/member-gallery.component';
import { MemberEditComponent } from './member-edit/member-edit.component';
import { PhotoEditorComponent } from './photo-editor/photo-editor.component';



@NgModule({
  declarations: [
    MemberDetailComponent,
    MemberListComponent,
    MemberCardComponent,
    MemberGalleryComponent,
    MemberEditComponent,
    PhotoEditorComponent
  ],
  imports: [
    CommonModule,
    MemberRoutingModule,
    SharedModule
  ]
})
export class MemberModule { }
