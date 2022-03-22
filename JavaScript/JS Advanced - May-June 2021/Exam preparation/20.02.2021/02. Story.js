class Story {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
    }
    get likes() {
        if (this._likes.length == 0) { return `${this.title} has 0 likes`; }
        else if (this._likes.length == 1) { return `${this._likes[0]} likes this story!`; }
        else {
            return `${this._likes[0]} and ${this._likes.length - 1} others like this story!`;
        }
    }
    like(username) {
        if (this._likes.includes(username)) { throw new Error("You can't like the same story twice!"); }
        else if (this.creator === username) { throw new Error("You can't like your own story!"); }
        else { this._likes.push(username); return `${username} liked ${this.title}!`; }
    }
    dislike(username) {
        if (!this._likes.includes(username)) { throw new Error("You can't dislike this story!"); }
        else {
            let i = this._likes.indexOf(username);
            this._likes.splice(i, 1);
            return `${username} disliked ${this.title}`;
        }
    }
    comment(username, content, id) {
        let isFound = false;
        if (id != undefined) {
            for (let i = 0; i < this._comments.length; i++) {
                if (this._comments[i].id === id) {
                    isFound = true;
                    let currReply = {
                        id: `${id}.${this._comments[i].replies.length + 1}`,
                        username: username,
                        content: content,
                    };
                    this._comments[i].replies.push(currReply);
                    return 'You replied successfully';
                }
            }
        }
        if (!id || !isFound) {
            let currComment = {
                id: this._comments.length + 1,
                username: username,
                content: content,
                replies: []
            };
            this._comments.push(currComment);
            return `${username} commented on ${this.title}`;
        }
    }
    toString(sortingType) {
        let result = `Title: ${this.title}\nCreator: ${this.creator}\nLikes: ${this._likes.length}\n`;
        result += `Comments:\n`;
        let sorted = this._comments;
        if (sortingType == 'asc') {
            sorted.sort((a, b) => a.id - b.id);
            for (let i = 0; i < sorted.length; i++) {
                sorted[i].replies.sort((a, b) => a.id.localeCompare(b.id));
            }
        }
        else if (sortingType == 'desc') {
            sorted.sort((a, b) => b.id - a.id);
            for (let i = 0; i < sorted.length; i++) {
                sorted[i].replies.sort((a, b) => b.id.localeCompare(a.id));
            }
        }
        else if (sortingType == 'username') {
            sorted.sort((a, b) => a.username.localeCompare(b.username));
            for (let i = 0; i < sorted.length; i++) {
                sorted[i].replies.sort((a, b) => a.username.localeCompare(b.username));
            }
        }
        for (let i = 0; i < sorted.length; i++) {
            result += `-- ${sorted[i].id}. ${sorted[i].username}: ${sorted[i].content}\n`;
            for (let r = 0; r < sorted[i].replies.length; r++) {
                result += `--- ${sorted[i].replies[r].id}. ${sorted[i].replies[r].username}: ${sorted[i].replies[r].content}\n`
            }
        }
        return result.trimEnd();
    }
}

let art = new Story("My Story", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.dislike("Sally");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('desc'));
