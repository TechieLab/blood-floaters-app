import {ILookupService, LookupService} from '../services/lookup.service';
import {IUserService, UserService} from '../services/user.service';
import {IUploadService, UploadService} from '../services/upload.service';
import {AuthGuard} from '../services/guard.service';

export const AppProviders = [
    {
        provide: LookupService,
        useClass: LookupService
    }, {
        provide: UserService,
        useClass: UserService
    }, {
        provide: UploadService,
        useClass: UploadService
    }, {
        provide: AuthGuard,
        useClass: AuthGuard
    }
];