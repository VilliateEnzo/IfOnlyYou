import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PreventUnsavedChangesGuard } from '../_guards/prevent-unsaved-changes.guard';
import { MemberDetailComponent } from './member-detail/member-detail.component';
import { MemberEditComponent } from './member-edit/member-edit.component';
import { MemberListComponent } from './member-list/member-list.component';

const routes: Routes = [
  { path: '', component: MemberListComponent },
  { path: 'detail/:username', component: MemberDetailComponent },
  { path: 'edit', component: MemberEditComponent, canDeactivate: [PreventUnsavedChangesGuard] }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MemberRoutingModule { }
