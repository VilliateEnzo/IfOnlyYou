export class MenuOption {
    Name: string;
    Link: string;
    TieneLink: boolean;
    TieneClick: boolean;
    ClickFunction: string;

    public constructor(name: string, link: string, tieneLink: boolean, tieneClick: boolean, clickFunction: string) {
        this.Name = name;
        this.Link = link;
        this.ClickFunction = clickFunction;
        this.TieneClick = tieneClick;
        this.TieneLink = tieneLink;
    }
}