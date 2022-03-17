class ChristmasMovies {
    constructor() {
        this.movieCollection = [];
        this.watched = {};
        this.actors = [];
    }

    buyMovie(movieName, actors) {
        let movie = this.movieCollection.find(m => movieName === m.name);
        let uniqueActors = new Set(actors);

        if (movie === undefined) {
            this.movieCollection.push({ name: movieName, actors: [...uniqueActors] });
            let output = [];
            [...uniqueActors].map(actor => output.push(actor));
            return `You just got ${movieName} to your collection in which ${output.join(', ')} are taking part!`;
        } else {
            throw new Error(`You already own ${movieName} in your collection!`);
        }
    }

    discardMovie(movieName) {
        let filtered = this.movieCollection.filter(x => x.name === movieName)

        if (filtered.length === 0) {
            throw new Error(`${movieName} is not at your collection!`);
        }
        let index = this.movieCollection.findIndex(m => m.name === movieName);
        this.movieCollection.splice(index, 1);
        let { name, _ } = filtered[0];
        if (this.watched.hasOwnProperty(name)) {
            delete this.watched[name];
            return `You just threw away ${name}!`;
        } else {
            throw new Error(`${movieName} is not watched!`);
        }

    }

    watchMovie(movieName) {
        let movie = this.movieCollection.find(m => movieName === m.name);
        if (movie) {
            if (!this.watched.hasOwnProperty(movie.name)) {
                this.watched[movie.name] = 1;
            } else {
                this.watched[movie.name]++;
            }
        } else {
            throw new Error('No such movie in your collection!');
        }
    }

    favouriteMovie() {
        let favourite = Object.entries(this.watched).sort((a, b) => b[1] - a[1]);
        if (favourite.length > 0) {
            return `Your favourite movie is ${favourite[0][0]} and you have watched it ${favourite[0][1]} times!`;
        } else {
            throw new Error('You have not watched a movie yet this year!');
        }
    }

    mostStarredActor() {
        let mostStarred = {};
        if (this.movieCollection.length > 0) {
            this.movieCollection.forEach(el => {
                let { _, actors } = el;
                actors.forEach(actor => {
                    if (mostStarred.hasOwnProperty(actor)) {
                        mostStarred[actor]++;
                    } else {
                        mostStarred[actor] = 1;
                    }
                })
            });
            let theActor = Object.entries(mostStarred).sort((a, b) => b[1] - a[1]);
            return `The most starred actor is ${theActor[0][0]} and starred in ${theActor[0][1]} movies!`;
        } else {
            throw new Error('You have not watched a movie yet this year!')
        }
    }
}
const { assert } = require("chai");
//let { ChristmasMovies } = require("../02. Christmas Movies.js");

it('valid construction', ()=>{
    let christmas = new ChristmasMovies();
    assert.deepEqual(christmas.movieCollection, []);
    assert.strictEqual(christmas.movieCollection.length, 0);
    assert.deepEqual(christmas.watched, {});
    assert.deepEqual(christmas.actors, []);
    assert.strictEqual(christmas.actors.length, 0);   
});
it('buyMovie vaid with 1 actor',()=>{
    let christmas = new ChristmasMovies();
    let actual = christmas.buyMovie('Home alone', ['Macaulay Culkin']);
    let expected = 'You just got Home alone to your collection in which Macaulay Culkin are taking part!';
    assert.strictEqual(actual, expected);
})
it('buyMovie vaid with 1 repeating actor',()=>{
    let christmas = new ChristmasMovies();
    let actual = christmas.buyMovie('Home alone', ['Macaulay Culkin','Macaulay Culkin']);
    let expected = 'You just got Home alone to your collection in which Macaulay Culkin are taking part!';
    assert.strictEqual(actual, expected);
})
it('buyMovie vaid with several actors',()=>{
    let christmas = new ChristmasMovies();
    let actual = christmas.buyMovie('Ice age', ['Mani', 'Sid', 'Diego']);
    let expected = 'You just got Ice age to your collection in which Mani, Sid, Diego are taking part!';
    assert.strictEqual(actual, expected);
})
it('buyMovie invalid',()=>{
    let christmas = new ChristmasMovies();
    let actual = christmas.buyMovie('Ice age', ['Mani', 'Sid', 'Diego']);
    let expected = 'You just got Ice age to your collection in which Mani, Sid, Diego are taking part!';
    assert.strictEqual(actual, expected);
    assert.throws(()=>christmas.buyMovie('Ice age', ['Mani', 'Sid', 'Diego']), 'You already own Ice age in your collection!');
})
it('watch valid', ()=>{
    let christmas = new ChristmasMovies();
    christmas.buyMovie('Home alone', ['Macaulay Culkin']);
    christmas.watchMovie('Home alone');
    assert.strictEqual(christmas.watched['Home alone'], 1);
})
it('watch valid 2nd time', ()=>{
    let christmas = new ChristmasMovies();
    christmas.buyMovie('Home alone', ['Macaulay Culkin']);
    christmas.watchMovie('Home alone');
    christmas.watchMovie('Home alone');
    assert.strictEqual(christmas.watched['Home alone'], 2);
})
it('watch invalid', ()=>{
    let christmas = new ChristmasMovies();     
    assert.throws(()=>christmas.watchMovie('Home alone'), 'No such movie in your collection!');
})
it('favourite valid',()=>{
    let christmas = new ChristmasMovies();
    christmas.buyMovie('Home alone', ['Macaulay Culkin']);
    christmas.buyMovie('Ice age', ['Mani', 'Sid', 'Diego']);
    christmas.watchMovie('Home alone');
    christmas.watchMovie('Ice age');
    christmas.watchMovie('Home alone');
    assert.strictEqual(christmas.favouriteMovie(), 'Your favourite movie is Home alone and you have watched it 2 times!');
})
it('favourite valid with only 1 watched',()=>{
    let christmas = new ChristmasMovies();
    christmas.buyMovie('Home alone', ['Macaulay Culkin']);
    christmas.watchMovie('Home alone');
    assert.strictEqual(christmas.favouriteMovie(), 'Your favourite movie is Home alone and you have watched it 1 times!');
})
it('favourite invalid', ()=>{
    let christmas = new ChristmasMovies();     
    assert.throws(()=>christmas.favouriteMovie(), 'You have not watched a movie yet this year!');
})
it('mostStarredActor valid with 1 movie',()=>{
    let christmas = new ChristmasMovies();
    christmas.buyMovie('Home alone', ['Macaulay Culkin']);
    christmas.watchMovie('Home alone');
    assert.strictEqual(christmas.mostStarredActor(), 'The most starred actor is Macaulay Culkin and starred in 1 movies!');
})
it('mostStarredActor valid',()=>{
    let christmas = new ChristmasMovies();
    christmas.buyMovie('Home alone', ['Macaulay Culkin']);
    christmas.buyMovie('Home alone2', ['Macaulay Culkin', 'Other guy']);
    christmas.watchMovie('Home alone');
    christmas.watchMovie('Home alone2');
    assert.strictEqual(christmas.mostStarredActor(), 'The most starred actor is Macaulay Culkin and starred in 2 movies!');
})
it('mostStarredActor invalid', ()=>{
    let christmas = new ChristmasMovies();     
    assert.throws(()=>christmas.mostStarredActor(), 'You have not watched a movie yet this year!');
})
it('discard valid', ()=>{
    let christmas = new ChristmasMovies();
    christmas.buyMovie('Home alone', ['Macaulay Culkin']);
    christmas.watchMovie('Home alone');
    assert.strictEqual(christmas.discardMovie('Home alone'), 'You just threw away Home alone!');
})
it('discard invalid', ()=>{
    let christmas = new ChristmasMovies(); 
    assert.throws(()=>christmas.discardMovie('Home alone'), 'Home alone is not at your collection!');
})
it('discard unwatched', ()=>{
    let christmas = new ChristmasMovies();
    christmas.buyMovie('Home alone', ['Macaulay Culkin']);   
    assert.throws(()=>christmas.discardMovie('Home alone'), 'Home alone is not watched!');
})