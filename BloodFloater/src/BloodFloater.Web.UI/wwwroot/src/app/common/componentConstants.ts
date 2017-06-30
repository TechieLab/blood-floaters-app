import { HeaderComponent } from '../components/layout/header.component';
import { HomePage } from '../../pages/home/home.page';
import { Welcome } from '../../pages/welcome/welcome.page';

import { SettingsPage } from '../../pages/settings/settings.page';
import { NotificationPage } from '../../pages/notification/notification.page';
import { FeedbackPage } from '../../pages/feedback/feedback.page';
import { HelpPage } from '../../pages/help/help.page';

export const AppComponents = [
    HeaderComponent,
    HomePage,
    Welcome,
    SettingsPage,
    NotificationPage,
    FeedbackPage,
    HelpPage
];

export const featuredComponents = [
    FeedbackPage,
    HelpPage
];

export const customPipes = [
    
];

export const appPages = [
    { title: 'Home', component: HomePage, name: "home", seq: 1 },
    { title: 'About', component: HomePage, name: "book", seq: 7 },
    { title: 'Feedback', component: FeedbackPage, name: "paper", seq: 6 },
    { title: 'Help', component: HelpPage, name: "help-circle", seq: 8 }

];

export const authPages = [    
    { title: 'Settings', component: SettingsPage, name: "settings", seq: 5 }
];