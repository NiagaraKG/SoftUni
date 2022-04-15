const { chromium } = require('playwright-chromium');
const { assert, expect } = require('chai');
let browser, page;

describe('Books tests', function () {
    this.timeout(100000);
    before(async () => { browser = await chromium.launch({headless: false, slowMo: 600}); });
    after(async () => { await browser.close(); });
    beforeEach(async () => { page = await browser.newPage(); });
    afterEach(async () => { await page.close(); });

    it('Load', async () => {
        await page.goto('http://localhost:3000/');
        await page.click('text=LOAD ALL BOOKS');
        await page.waitForSelector('tbody tr td');
        let title1 = await page.$eval('tbody tr:first-child :first-child', (el) => el.textContent);
        let author1 = await page.$eval('tbody tr:first-child :nth-child(2)', (el) => el.textContent);
        let title2 = await page.$eval('tbody tr:nth-child(2) :first-child', (el) => el.textContent);
        let author2 = await page.$eval('tbody tr:nth-child(2) :nth-child(2)', (el) => el.textContent);
        assert.strictEqual(title1, 'Harry Potter and the Philosopher\'s Stone');
        assert.strictEqual(author1, 'J.K.Rowling');
        assert.strictEqual(title2, 'C# Fundamentals');
        assert.strictEqual(author2, 'Svetlin Nakov');
    });

    it('Add', async () => {
        await page.goto('http://localhost:3000/');
        await page.fill('[name="title"]', 'Winnie-the-Pooh');
        await page.fill('[name="author"]', 'A. A. Milne');
        await page.click('text=Submit');
        await page.click('text=LOAD ALL BOOKS');
        await page.waitForSelector('tbody tr td');
        let title = await page.$eval('tbody tr:nth-child(3) :first-child', (el) => el.textContent);
        let author = await page.$eval('tbody tr:nth-child(3) :nth-child(2)', (el) => el.textContent);
        assert.strictEqual(title, 'Winnie-the-Pooh');
        assert.strictEqual(author, 'A. A. Milne');
    });

    it('Edit', async () => {
        await page.goto('http://localhost:3000/');
        await page.click('text=LOAD ALL BOOKS');
        await page.click('text=Edit');
        await page.fill('text=Edit FORM TITLE AUTHOR Save >> [name="author"]', 'Joan Rowling');
        await page.click('text=Save');
        await page.click('text=LOAD ALL BOOKS');
        let title = await page.$eval('tbody tr:first-child :first-child', (el) => el.textContent);
        let author = await page.$eval('tbody tr:first-child :nth-child(2)', (el) => el.textContent);
        assert.strictEqual(title, 'Harry Potter and the Philosopher\'s Stone');
        assert.strictEqual(author, 'Joan Rowling');
    });

    it('Delete', async () => {
        await page.goto('http://localhost:3000/');
        await page.click('text=LOAD ALL BOOKS');
        page.on('dialog', (dialog) => { dialog.accept(); });

        await page.click('tbody tr:nth-child(2) .deleteBtn');
        await page.click('#loadBooks');

        let title = await page.$eval('tbody tr:nth-child(2) :first-child', (el) => el.textContent);
        let author = await page.$eval('tbody tr:nth-child(2) :nth-child(2)', (el) => el.textContent);

        assert.strictEqual(title, 'Winnie-the-Pooh');
        assert.strictEqual(author, 'A. A. Milne');
    });
});