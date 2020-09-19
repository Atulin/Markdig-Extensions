# Markdig Extensions

A collection of [Markdig](https://github.com/lunet-io/markdig) extensions I made to use in my projects. Some might be too specific to them, but some might come useful to others. Hence the [MIT license](LICENSE.md)

## List of extensions

### Hashtags

Finds all occurrences of `#tag`, `#another-tag` or `#yet_another_tag` and turns them into links according to the following scheme:

```html
<a href="[baseUrl][tag]" target="[target]">#[tag]</a>
```

### Mentions

Finds all occurrences of `@username` and turns them into links according to the following scheme:

```html
<a href="[baseUrl][username]" target="[target]">@[username]</a>
```

### Spoilers

Finds all occurrences of `||text||` and turns them into spoiler tags according to the following scheme

```html
<span class="spoiler">[text]</span>
```
