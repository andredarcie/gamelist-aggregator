<script>
  import GameList from './pages/GameList.svelte';
  import GameDetails from './pages/GameDetails.svelte';

  let currentPath = window.location.pathname;
  let gameId = null;

  function navigate(path) {
    currentPath = path;
    history.pushState({}, '', path);
  }

  window.addEventListener('popstate', () => {
    currentPath = window.location.pathname;
  });
  function parsePath(path) {
    const match = path.match(/^\/game\/(\d+)/);
    if (match) {
      gameId = match[1];
      return 'details';
    }
    gameId = null;
    return 'list';
  }

  $: page = parsePath(currentPath);
</script>

{#if page === 'list'}
  <GameList />
{:else if page === 'details'}
  <GameDetails {gameId} />
{/if}
