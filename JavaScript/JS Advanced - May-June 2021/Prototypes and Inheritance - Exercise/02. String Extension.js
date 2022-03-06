(function extendString() {

    String.prototype.ensureStart = function (str) {
        if (!this.startsWith(str)) { return str.concat(this); }
        return this.toString();
    };

    String.prototype.ensureEnd = function (str) {
        if (!this.endsWith(str)) { return this.concat(str); }
        return this.toString();
    };

    String.prototype.isEmpty = function () { return this.length == 0; };
    
    String.prototype.truncate = function (n) {
        if (this.length <= n) { return this.toString(); }
        if (n < 4) { return '.'.repeat(n); }
        if (!this.includes(' ')) { return this.slice(0, n-3) + '...'; }
        let words = this.split(' ').map((el) => el + ' ');
        let result = '';
        let i = 0;
        while ((result + words[i]).length < n) { result += words[i]; i++; }
        if (result == '') { return words[0].slice(0, n - 3) + '...'; }
        return result.trim() + '...';
    };

    String.format = function (str, ...params) {
        params.forEach((key, i) => {str = str.replace(`{${i}}`, key);});
        return str;
    };

})();