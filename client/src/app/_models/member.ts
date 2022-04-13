import { Interest } from "./interest";
import { Photo } from "./photo";

export interface Member {
    id: number;
    userName: string;
    photoUrl: string;
    introduction: string;
    age: number;
    knownAs: string;
    createdAt: Date;
    lastActiveAt: Date;
    gender: string;
    lookingFor: string;
    interests: Interest[];
    city: string;
    country: string;
    photos: Photo[];
}