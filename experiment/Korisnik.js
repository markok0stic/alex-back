let instance;
export class Korisnik{
    instance = null;
    constructor(broj)
    {
        if (!instance)
        instance=this;
        this.id=broj;
    }
    static suba()
    {
        alert(instance.id);
    }
}