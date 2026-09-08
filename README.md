```shell
curl --silent --url 'https://zimapi.bob.house/library' | jq '.[] | select(.title=="Movies by Wikipedia")'
```

results

```json
{
  "id": "urn:uuid:692eb0f1-bdfb-4d0c-ffcb-763872973aad",
  "uri": "https://lb.download.kiwix.org/zim/wikipedia/wikipedia_en_movies_maxi_2026-07.zim.meta4",
  "title": "Movies by Wikipedia",
  "name": "wikipedia_en_movies",
  "flavor": "maxi",
  "date": "2026-07-09"
}
{
  "id": "urn:uuid:766d64c5-6dff-522f-4fc9-287e8283e60e",
  "uri": "https://lb.download.kiwix.org/zim/wikipedia/wikipedia_en_movies_nopic_2026-07.zim.meta4",
  "title": "Movies by Wikipedia",
  "name": "wikipedia_en_movies",
  "flavor": "nopic",
  "date": "2026-07-09"
}
```

```shell
curl --silent --url 'https://zimapi.bob.house/metadata?uri=https%3A%2F%2Flb.download.kiwix.org%2Fzim%2Fwikipedia%2Fwikipedia_en_movies_maxi_2026-07.zim.meta4' | jq
```

results

```json
[
  "https://www.mirrorservice.org/sites/download.kiwix.org/zim/wikipedia/wikipedia_en_movies_maxi_2026-07.zim",
  "https://ftp.nluug.nl/pub/kiwix/zim/wikipedia/wikipedia_en_movies_maxi_2026-07.zim",
  "https://mirror.download.kiwix.org/zim/wikipedia/wikipedia_en_movies_maxi_2026-07.zim",
  "https://mirrors.dotsrc.org/kiwix/zim/wikipedia/wikipedia_en_movies_maxi_2026-07.zim",
  "https://mirror.accum.se/mirror/kiwix.org/zim/wikipedia/wikipedia_en_movies_maxi_2026-07.zim",
  "https://ftp.fau.de/kiwix/zim/wikipedia/wikipedia_en_movies_maxi_2026-07.zim",
  "https://mirror-sites-fr.mblibrary.info/mirror-sites/download.kiwix.org/zim/wikipedia/wikipedia_en_movies_maxi_2026-07.zim",
  "https://wi.mirror.driftle.ss/kiwix/zim/wikipedia/wikipedia_en_movies_maxi_2026-07.zim",
  "https://dumps.wikimedia.org/kiwix/zim/wikipedia/wikipedia_en_movies_maxi_2026-07.zim",
  "https://mirror-sites-in.mblibrary.info/mirror-sites/download.kiwix.org/zim/wikipedia/wikipedia_en_movies_maxi_2026-07.zim"
]
```
