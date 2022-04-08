export class MenuOption {
    Name: string;
    Link: string;
    TieneLink: boolean;

    public constructor(name: string, link: string, tieneLink: boolean) {
        this.Name = name;
        this.Link = link;
        this.TieneLink = tieneLink;
    }
}