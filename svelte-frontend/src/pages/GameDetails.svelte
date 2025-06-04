<script>
  import { onMount } from 'svelte';
  export let gameId;
  let game;
  let score;
  onMount(async () => {
    const res = await fetch(`/api/games/${gameId}`);
    game = await res.json();
    const resScore = await fetch(`/api/games/${gameId}/score`);
    score = await resScore.json();
  });
</script>

{#if game}
<h1>{game.title}</h1>
<p>Score: {score}</p>
<a href="/">Back to list</a>
{/if}
