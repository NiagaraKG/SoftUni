const { chromium } = require('playwright-chromium');
const { assert } = require('chai');
let browser, page;

describe('Messenger tests', function () {
    this.timeout(10000);
    before(async () => { browser = await chromium.launch(); });
    //before(async () => { browser = await chromium.launch({ headless: false, slowMo: 200 }); });
    after(async () => { await browser.close(); });
    beforeEach(async () => { page = await browser.newPage(); });
    afterEach(async () => { await page.close(); });

    it('Load initial messages', async () => {
        await page.goto('http://localhost:3000/');
        await page.click('text=Refresh');
        let messages = await page.$eval('#messages', (el) => el.value.split('\n'));
        assert.strictEqual(messages[0], 'Spami: Hello, are you there?');
        assert.strictEqual(messages[1], 'Garry: Yep, whats up :?');
        assert.strictEqual(messages[2], 'Spami: How are you? Long time no see? :)');
        assert.strictEqual(messages[3], 'George: Hello, guys! :))');
        assert.strictEqual(messages[4], 'Spami: Hello, George nice to see you! :)))');
    });
    it('Send message', async () => {
        await page.goto('http://localhost:3000/');
        await page.fill('[id="author"]', 'Peter');
        await page.fill('[id="content"]', 'Sup?');
        await page.click('text=Send');
        await page.click('text=Refresh');
        let messages = await page.evaluate(() => {
            let text = document.getElementById('messages').value;
            return text.split('\n');
        });
        assert.strictEqual(messages[0], 'Spami: Hello, are you there?');
        assert.strictEqual(messages[1], 'Garry: Yep, whats up :?');
        assert.strictEqual(messages[2], 'Spami: How are you? Long time no see? :)');
        assert.strictEqual(messages[3], 'George: Hello, guys! :))');
        assert.strictEqual(messages[4], 'Spami: Hello, George nice to see you! :)))');
        assert.strictEqual(messages[5], 'Peter: Sup?');
    });
});
