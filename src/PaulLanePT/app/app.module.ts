﻿import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";

import { AppComponent }  from "./app.component";
import { BackgroundVideoComponent } from "./home/background-video.component";
import { SectionOneComponent } from "./home/section-one.component";
import { PricesComponent } from "./home/prices.component";
import { AboutComponent } from "./home/about.component";

@NgModule({
    imports: [
        BrowserModule
    ],
    declarations: [
        AppComponent,
        BackgroundVideoComponent,
        SectionOneComponent,
        PricesComponent,
        AboutComponent
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule { }
