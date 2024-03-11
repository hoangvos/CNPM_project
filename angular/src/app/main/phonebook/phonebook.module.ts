import {NgModule} from '@angular/core';
import {AppSharedModule} from '@app/shared/app-shared.module';
import {PhoneBookRoutingModule} from './phonebook-routing.module';
import {PhoneBookComponent} from './phonebook.component';
import {CreatePersonModalComponent} from './create-person-modal.component';

@NgModule({
    declarations: [PhoneBookComponent, CreatePersonModalComponent],
    imports: [AppSharedModule, PhoneBookRoutingModule]
})
export class PhoneBookModule {}
