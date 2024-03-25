import { Component, Injector, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {
    CommonLookupServiceProxy,
    EntityDtoOfInt64,
    FindUsersInput,
    NameValueDto,
    TenantListDto,
    TenantServiceProxy,
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { DocumentServiceProxy, DocumentListDto, ListResultDtoOfDocumentListDto } from '@shared/service-proxies/service-proxies';
import { CreateDocumentComponent } from './create-document/create-document.component';

@Component({
    templateUrl: './documents.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()]
})
export class DocumentsComponent extends AppComponentBase implements OnInit {
    @ViewChild('createDocumentModal', { static: false }) createDocumentModal: CreateDocumentComponent;


    documents: DocumentListDto[] = [];
    filter: string = '';

    constructor(
        injector: Injector,
        private _DocumentService: DocumentServiceProxy
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.getDocuments();
    }
    getDocuments(): void {
        this._DocumentService.getDocuments(this.filter).subscribe((result) => {
            this.documents = result.items;
        });
    }
    createDocument(): void {
        this.createDocumentModal.show();
    }

}
