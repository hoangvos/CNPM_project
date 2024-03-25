import {NgModule} from '@angular/core';
import {AppSharedModule} from '@app/shared/app-shared.module';
import {DocumentsRoutingModule} from './documents-routing.module';
import {DocumentsComponent} from './documents.component';
import { LoaiVanBanComponent } from './loai-van-ban.component';
import { CreateDocumentComponent } from './create-document/create-document.component';


@NgModule({
    declarations: [DocumentsComponent,LoaiVanBanComponent, CreateDocumentComponent, CreateDocumentComponent],
    imports: [AppSharedModule, DocumentsRoutingModule ]
})
export class DocumentsModule {}
