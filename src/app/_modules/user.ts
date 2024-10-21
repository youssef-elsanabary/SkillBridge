export class User {
    constructor(
    public username : string,
    public email : string,
    public password : string,
    public role : string,
    public image? :string,
    public description? :string,
    public bio? :string,
    public skills? :string,
    public cvFile? :string,
    public dataCreated? :Date,
    ){}
}
