import { html, render } from "../node_modules/lit-html/lit-html.js";
let hostURL = `http://localhost:3030/jsonstore/collections/books`;
let ctx = {
    list: [],
    async load() {
        ctx.list = await getAllBooks();
        update();
    },
    onEdit(id) {
        let book = ctx.list.find(b => b._id == id);
        update(book);
    },
    async onDelete(id) {
        let confirmed = confirm('Do you want to delete this book?');
        if (confirmed) { await deleteBook(id); }
    }
};

let templateRow = book => html`
<tr>
    <td>${book.title}</td>
    <td>${book.author}</td>
    <td id=${book._id}>
        <button class="editBtn">Edit</button>
        <button class="deleteBtn">Delete</button>
    </td>
</tr>`;

let templateTable = ctx => html`
<table>
    <thead>
        <tr>
            <th>Title</th>
            <th>Author</th>
            <th>Action</th>
        </tr>
    </thead>
    <tbody @click=${e => onClick(e, ctx)}>
        ${ctx.list.map(templateRow)}
    </tbody>
</table>`;

let templateCreate = () => html`
<form id="add-form">
    <h3>Add book</h3>
    <label>TITLE</label>
    <input type="text" name="title" placeholder="Title...">
    <label>AUTHOR</label>
    <input type="text" name="author" placeholder="Author...">
    <input type="submit" value="Submit">
</form>`;

let templateEdit = book => html`
<form id="edit-form">
    <input type="hidden" name="_id" .value=${book._id}>
    <h3>Edit book</h3>
    <label>TITLE</label>
    <input type="text" name="title" placeholder="Title..." .value=${book.title}>
    <label>AUTHOR</label>
    <input type="text" name="author" placeholder="Author..." .value=${book.author}>
    <input type="submit" value="Save">
</form>`;

let templateLayout = (ctx, book) => html`
<button @click=${ctx.load} id="loadBooks">LOAD ALL BOOKS</button>
${templateTable(ctx)}
${book ? templateEdit(book) : templateCreate()}`;

function onClick(e, ctx) {
    if (e.target.classList.contains('editBtn')) {
        let id = e.target.parentNode.id;
        ctx.onEdit(id);
    }
    else if (e.target.classList.contains('deleteBtn')) {
        let id = e.target.parentNode.id;
        ctx.onDelete(id);
    }
}

async function request(url, options) {
    let response = await fetch(url, options);
    let data = await response.json();
    return data;
}

async function getAllBooks() {
    return Object.entries(await request(hostURL))
        .map(([k, v]) => Object.assign(v, { _id: k }));
}

async function getBook(id) { return await request(`${hostURL}/${id}`); }

async function createBook(book) {
    return await request(hostURL, {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(book)
    });
}

async function updateBook(id, book) {
    return await request(`${hostURL}/${id}`, {
        method: 'put',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(book)
    });
}

async function deleteBook(id) {
    return await request(`${hostURL}/${id}`, { method: 'delete', });
}

async function start() { update(); }

function update(book) {
    let result = templateLayout(ctx, book);
    render(result, document.body);
}

document.body.addEventListener('submit', (e) => {
    e.preventDefault();
    let formData = new FormData(e.target);
    onSubmit[e.target.id](formData, e.target);
});

let onSubmit = {
    'add-form': submitCreate,
    'edit-form': submitEdit
};

async function submitCreate(formData, form) {
    let book = {
        title: formData.get('title'),
        author: formData.get('author')
    };
    await createBook(book);
    form.reset();
}

async function submitEdit(formData, form) {
    let id = formData.get('_id');
    let book = {
        title: formData.get('title'),
        author: formData.get('author')
    };
    await updateBook(id, book);
    form.reset();
    update();
}

start();

/*За да се видят промените при Edit/Delete/Create 
трябва да се презаредят книгите от бутона 'LOAD ALL BOOKS'*/