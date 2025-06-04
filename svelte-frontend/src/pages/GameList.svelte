<script>
  import { onMount } from 'svelte';
  let games = [];
  onMount(async () => {
    const res = await fetch('/api/games');
    games = await res.json();
  });
</script>

<h1>Game List</h1>
<ul>
  {#each games as game}
    <li><a href={'/game/' + game.id}>{game.title}</a></li>
  {/each}
</ul>
