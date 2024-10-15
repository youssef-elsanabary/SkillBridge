export class Profile {
    constructor(
        public profileId : number,
        public name : string,
        public image :string,
        public description :string,
        public bio :string,
        public skills :string,
        public cvFile :string,
        public dataCreated :Date,
    ){}
}