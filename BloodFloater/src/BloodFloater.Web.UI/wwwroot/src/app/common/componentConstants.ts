import { HeaderComponent } from '../components/layout/header.component';
import { HomePage , WelcomePage , SettingsPage ,NotificationPage ,FeedbackPage , HelpPage } from '../../pages';

export const AppComponents = [
    HeaderComponent,
    HomePage,
    WelcomePage,
    SettingsPage,
    NotificationPage,
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