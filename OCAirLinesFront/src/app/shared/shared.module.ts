import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasicModalComponent } from './basic-modal/basic-modal.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { DragDropModule } from '@angular/cdk/drag-drop';

@NgModule({
  declarations: [BasicModalComponent, PageNotFoundComponent],
  imports: [CommonModule, DragDropModule]
})
export class SharedModule {}
