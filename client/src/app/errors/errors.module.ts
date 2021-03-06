import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TestErrorsComponent } from './test-errors/test-errors.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { ErrorsRoutingModule } from './errors-routing.module';
import { ServerErrorComponent } from './server-error/server-error.component';


@NgModule({
    declarations: [
        TestErrorsComponent,
        NotFoundComponent,
        ServerErrorComponent,
    ],
    imports: [
        CommonModule,
        ErrorsRoutingModule
    ]
})
export class ErrorsModule { }
