import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";

import { AppComponent }  from "./app.component";
import { BackgroundVideoComponent } from "./home/background-video.component";
import { SectionOneComponent } from "./home/section-one.component";

@NgModule({
    imports: [
        BrowserModule
    ],
    declarations: [
        AppComponent,
        BackgroundVideoComponent,
        SectionOneComponent
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule { }
