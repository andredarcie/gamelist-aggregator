<script>
  let games = [];

  async function loadGames() {
    const res = await fetch('/api/games');
    games = await res.json();
  }

  loadGames();
</script>

<main>
  <h1>Game List</h1>
  <ul>
    {#each games as game}
      <li>{game.title}</li>
    {/each}
  </ul>
</main>
